
using System.Text.Json;
using NUnit.Framework;
using SPM.Tourism.Api.Services;

namespace SPM.Tourism.Api.Tests;

[TestFixture]
public class TourismContentMapperTests
{
    [Test]
    public void Map_ValidJson_CreatesContentAndCleansHtml()
    {
        // Arrange: prepare a valid JSON record
        string json = """
        {
            "id": "39782f97-e126-44aa-964f-b00af4476885",
            "name": "  Rocca di Gradara  ",
            "description": "<p>La <strong>Rocca</strong> &amp; il borgo</p>",
            "typology": "Castello",
            "imagePath": null
        }
        """;

        using JsonDocument document = JsonDocument.Parse(json);

        // Act: transform the JSON into TourismContent
        var result = TourismContentMapper.Map(
            document.RootElement, "cultural-institutes-or-sites");

        // Assert: verify the transformed values
        Assert.That(result, Is.Not.Null);
        Assert.That(result?.Name, Is.EqualTo("Rocca di Gradara"));
        Assert.That(result?.Description,
            Is.EqualTo("La Rocca & il borgo"));
        Assert.That(result?.Municipality, Is.EqualTo("Gradara"));
        Assert.That(result?.Typology, Is.EqualTo("Castello"));
    }

    [Test]
    public void Map_InvalidGuid_ReturnsNull()
    {
        // Arrange: the identifier is not a valid GUID
        string json = """
        {
            "id": "invalid-id",
            "name": "Rocca di Gradara"
        }
        """;

        using JsonDocument document = JsonDocument.Parse(json);

        // Act
        var result = TourismContentMapper.Map(
            document.RootElement, "articles");

        // Assert: invalid records must be rejected
        Assert.That(result, Is.Null);
    }

    [Test]
    public void Map_EmptyName_ReturnsNull()
    {
        // Arrange: the required name contains only spaces
        string json = """
        {
            "id": "39782f97-e126-44aa-964f-b00af4476885",
            "name": "   "
        }
        """;

        using JsonDocument document = JsonDocument.Parse(json);

        // Act
        var result = TourismContentMapper.Map(
            document.RootElement, "articles");

        // Assert
        Assert.That(result, Is.Null);
    }

    [Test]
    public void Map_MissingOptionalFields_UsesNull()
    {
        // Arrange: valid JSON without optional properties
        string json = """
        {
            "id": "39782f97-e126-44aa-964f-b00af4476885",
            "name": "Rocca di Gradara"
        }
        """;

        using JsonDocument document = JsonDocument.Parse(json);

        // Act
        var result = TourismContentMapper.Map(
            document.RootElement, "articles");

        // Assert: the record is valid despite missing fields
        Assert.That(result, Is.Not.Null);
        Assert.That(result?.Description, Is.Null);
        Assert.That(result?.Typology, Is.Null);
        Assert.That(result?.ImagePath, Is.Null);
    }
}
