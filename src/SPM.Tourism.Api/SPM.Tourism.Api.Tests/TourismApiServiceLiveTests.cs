
using System;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using SPM.Tourism.Api.Services;

namespace SPM.Tourism.Api.Tests;

[TestFixture]
[Category("ExternalApi")]
public class TourismApiServiceLiveTests
{
    private class TestHttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient(string name)
        {
            return new HttpClient
            {
                BaseAddress = new Uri("https://apipublic.eppoi.io/"),
                Timeout = TimeSpan.FromSeconds(30)
            };
        }
    }

    [Test]
    public async Task GetAllPagesAsync_RetrievesGradaraContent()
    {
        var service = new TourismApiService(
            new TestHttpClientFactory());

        string[] categories =
        {
            "cultural-institutes-or-sites",
            "public-events",
            "paths",
            "articles"
        };

        int total = 0;

        foreach (string category in categories)
        {
            var items = await service.GetAllPagesAsync(category);

            TestContext.Progress.WriteLine(
                $"{category}: {items.Count} records");

            Assert.That(items.Count, Is.GreaterThan(0));

            total += items.Count;
        }

        TestContext.Progress.WriteLine(
            $"Total tourism records: {total}");
    }
}
