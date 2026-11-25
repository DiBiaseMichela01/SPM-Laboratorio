using Microsoft.EntityFrameworkCore;
using SPM.Tourism.Api.Data;
using SPM.Tourism.Api.Models;

namespace SPM.Tourism.Api.Services;

public class TourismContentStorageService
{
    private readonly ApplicationDbContext _dbContext;

    public TourismContentStorageService(
        ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> SaveNewContentsAsync(
        IEnumerable<TourismContent> contents)
    {
        // Check that the input collection is not null
        ArgumentNullException.ThrowIfNull(contents);

        // Track records already processed in this import
        var seen = new HashSet<(string Category, Guid ExternalId)>();

        int insertedCount = 0;

        foreach (TourismContent content in contents)
        {
            // Skip duplicates within the same import
            if (!seen.Add((content.Category, content.ExternalId)))
            {
                continue;
            }

            // Check whether the record is already in SQLite
            bool alreadyExists = await _dbContext.TourismContents
                .AnyAsync(existing =>
                    existing.Category == content.Category &&
                    existing.ExternalId == content.ExternalId);

            if (alreadyExists)
            {
                continue;
            }

            // Prepare the new record for insertion
            _dbContext.TourismContents.Add(content);
            insertedCount++;
        }

        // Save all new records to SQLite
        await _dbContext.SaveChangesAsync();

        return insertedCount;
    }
}
