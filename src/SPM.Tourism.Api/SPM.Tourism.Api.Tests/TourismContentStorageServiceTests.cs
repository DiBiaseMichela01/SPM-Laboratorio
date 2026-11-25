
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SPM.Tourism.Api.Data;
using SPM.Tourism.Api.Models;
using SPM.Tourism.Api.Services;

namespace SPM.Tourism.Api.Tests;

[TestFixture]
public class TourismContentStorageServiceTests
{
    [Test]
    public async Task SaveNewContentsAsync_InsertsNewRecords()
    {
        // Arrange: create a temporary SQLite database
        using var connection =
            new SqliteConnection("Data Source=:memory:");

        await connection.OpenAsync();

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite(connection)
            .Options;

        using var dbContext = new ApplicationDbContext(options);

        // Create the database tables
        await dbContext.Database.EnsureCreatedAsync();

        // Create the service we want to test
        var service = new TourismContentStorageService(dbContext);

        // Prepare two new tourism records
        var contents = new List<TourismContent>
        {
            new TourismContent
            {
                ExternalId = Guid.NewGuid(),
                Name = "Rocca di Gradara",
                Municipality = "Gradara",
                Category = "cultural-institutes-or-sites"
            },
            new TourismContent
            {
                ExternalId = Guid.NewGuid(),
                Name = "Museo di Gradara",
                Municipality = "Gradara",
                Category = "cultural-institutes-or-sites"
            }
        };

        // Act: save the records
        int inserted = await service.SaveNewContentsAsync(contents);

        // Assert: verify the result
        Assert.That(inserted, Is.EqualTo(2));

        int stored = await dbContext.TourismContents.CountAsync();

        Assert.That(stored, Is.EqualTo(2));
    }


    [Test]
    public async Task SaveNewContentsAsync_SkipsDuplicatesInSameImport()
    {
        // Arrange: create a temporary SQLite database
        using var connection =
            new SqliteConnection("Data Source=:memory:");

        await connection.OpenAsync();

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite(connection)
            .Options;

        using var dbContext = new ApplicationDbContext(options);

        await dbContext.Database.EnsureCreatedAsync();

        var service = new TourismContentStorageService(dbContext);

        // Use the same identifier for both records
        Guid externalId = Guid.NewGuid();

        var contents = new List<TourismContent>
    {
        new TourismContent
        {
            ExternalId = externalId,
            Name = "Rocca di Gradara",
            Municipality = "Gradara",
            Category = "cultural-institutes-or-sites"
        },
        new TourismContent
        {
            ExternalId = externalId,
            Name = "Rocca di Gradara",
            Municipality = "Gradara",
            Category = "cultural-institutes-or-sites"
        }
    };

        // Act: attempt to save both records
        int inserted = await service.SaveNewContentsAsync(contents);

        // Assert: only one record must be inserted
        Assert.That(inserted, Is.EqualTo(1));

        int stored = await dbContext.TourismContents.CountAsync();

        Assert.That(stored, Is.EqualTo(1));
    }

    // Test duplicate records already stored in SQLite
    [Test]
    public async Task SaveNewContentsAsync_SkipsExistingDatabaseRecords()
    {
        // Create an in-memory SQLite database
        using var connection =
            new SqliteConnection("Data Source=:memory:");

        // Open the database connection
        await connection.OpenAsync();


        // Configure SQLite for the test
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite(connection)
            .Options;

        // Use the same ID for both imports
        Guid externalId = Guid.NewGuid();

        // First import: prepare the database
        using (var firstContext = new ApplicationDbContext(options))
        {
            // Create the database tables
            await firstContext.Database.EnsureCreatedAsync();
            // Create the storage service
            var firstService = new TourismContentStorageService(firstContext);
            // Prepare a new tourism record
            var content = new TourismContent
            {
                ExternalId = externalId,
                Name = "Rocca di Gradara",
                Municipality = "Gradara",
                Category = "cultural-institutes-or-sites"
            };
            // Save the first record
            int inserted = await firstService.SaveNewContentsAsync(
                new[] { content });

            // Check the first insertion
            Assert.That(inserted, Is.EqualTo(1));

        }

        // Second import: use the same database
        using (var secondContext = new ApplicationDbContext(options))
        {
            // Create the storage service
            var secondService = new TourismContentStorageService(secondContext);
            // Prepare the duplicate record
            var duplicate = new TourismContent
            {
                ExternalId = externalId,
                Name = "Rocca di Gradara",
                Municipality = "Gradara",
                Category = "cultural-institutes-or-sites"
            };

            // Try to save the duplicate
            int inserted = await secondService.SaveNewContentsAsync(
                new[] { duplicate });

            // Check that no new records were inserted
            Assert.That(inserted, Is.EqualTo(0));
            // Count the records in SQLite
            int stored = await secondContext.TourismContents.CountAsync();

            // Check that only one record exists
            Assert.That(stored, Is.EqualTo(1));
        }
    }
}