
using System.Text.Json;
using SPM.Tourism.Api.Models;
using System.Net;
using System.Text.RegularExpressions;

namespace SPM.Tourism.Api.Services;

public static class TourismContentMapper
{
    public static TourismContent? Map(
        JsonElement item, string category)
    {
        if (item.ValueKind != JsonValueKind.Object ||
            string.IsNullOrWhiteSpace(category))
        {
            return null;
        }

        // Validate the external identifier
        if (!item.TryGetProperty("id", out JsonElement idElement) ||
            idElement.ValueKind != JsonValueKind.String ||
            !Guid.TryParse(idElement.GetString(), out Guid externalId))
        {
            return null;
        }

        // Validate the required name
        if (!item.TryGetProperty("name", out JsonElement nameElement) ||
            nameElement.ValueKind != JsonValueKind.String ||
            string.IsNullOrWhiteSpace(nameElement.GetString()))
        {
            return null;
        }

        // Transform the JSON into the database entity
        return new TourismContent
        {
            ExternalId = externalId,
            Name = nameElement.GetString()!.Trim(),
            Description = CleanDescription(
              GetOptionalString(item, "description")),
            Typology = GetOptionalString(item, "typology"),
            Municipality = "Gradara",
            Category = category,
            ImagePath = GetOptionalString(item, "imagePath")
        };
    }

    private static string? GetOptionalString(
        JsonElement item, string propertyName)
    {
        if (!item.TryGetProperty(propertyName, out JsonElement value) ||
            value.ValueKind != JsonValueKind.String)
        {
            return null;
        }

        string? text = value.GetString()?.Trim();

        return string.IsNullOrWhiteSpace(text) ? null : text;
    }

    private static string? CleanDescription(string? description)
    {
        // Check if the description is missing or empty
        if (string.IsNullOrWhiteSpace(description))
        {
            return null;
        }

        // Decode HTML entities
        string decoded = WebUtility.HtmlDecode(description);

        // Remove basic HTML tags
        string withoutTags = Regex.Replace(
            decoded, @"<[^>]*>", " ");

        // Remove repeated whitespace
        string cleaned = Regex.Replace(
            withoutTags, @"\s+", " ").Trim();

        return string.IsNullOrWhiteSpace(cleaned)
            ? null
            : cleaned;
    }
}
