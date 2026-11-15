using Microsoft.EntityFrameworkCore;

namespace SPM.Tourism.Api.Models
{
    [Index(nameof(Category), nameof(ExternalId), IsUnique = true)]
    public class TourismContent
    {
        public int Id { get; set; }

        public Guid ExternalId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Typology { get; set; }

        public string Municipality { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string? ImagePath { get; set; }
    }
}
