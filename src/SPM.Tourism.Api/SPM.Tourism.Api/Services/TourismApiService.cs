
using System.Net.Http;
using System.Text.Json;

namespace SPM.Tourism.Api.Services;

public class TourismApiService
{
    private readonly HttpClient _httpClient;

    public TourismApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("TourismApi");
    }

    public async Task<string> GetPageAsync(
        string category, int page, int pageSize)
    {
        string[] allowedCategories =
        {
            "cultural-institutes-or-sites",
            "public-events",
            "paths",
            "articles"
        };

        if (!allowedCategories.Contains(category))
        {
            throw new ArgumentException("Invalid tourism category.");
        }

        if (page < 1 || pageSize < 1)
        {
            throw new ArgumentException("Invalid pagination parameters.");
        }

        string url =
            $"api/public/{category}?municipality=Gradara&page={page}&pageSize={pageSize}";

        using HttpResponseMessage response =
            await _httpClient.GetAsync(url);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }


    public async Task<List<JsonElement>> GetAllPagesAsync(
        string category, int pageSize = 5)
    {
        var allItems = new List<JsonElement>();

        int totalPages = 1;

        for (int page = 1; page <= totalPages; page++)
        {
            // Retrieve the current page from the external API
            string json = await GetPageAsync(category, page, pageSize);

            // Convert the JSON response into a readable structure
            using JsonDocument document = JsonDocument.Parse(json);

            JsonElement root = document.RootElement;

            // Read the total number of pages from the first response
            if (page == 1)
            {
                totalPages = root.GetProperty("totalPages").GetInt32();
            }

            // Extract tourism records from the current page
            JsonElement items = root.GetProperty("items");

            foreach (JsonElement item in items.EnumerateArray())
            {
                allItems.Add(item.Clone());
            }
        }

        return allItems;
    }

}
