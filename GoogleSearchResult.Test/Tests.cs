using GoogleSearchResults.Google;
using GoogleSearchResults;
namespace GoogleSearchResult.Test
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public async Task GoogleSearchWithProxy_ShouldReturnResults()
        {
            var proxyOptions = new ProxyOptions()
            {
                UseProxy = true,
                IP = "IP",
                Port = "PORT",
                Username = "username",
                Password = "password",
            };
            List<GoogleSearchResults.Google.GoogleSearchResult> searchResults = new List<GoogleSearchResults.Google.GoogleSearchResult>();
            var search = new GoogleSearch();
            searchResults = await search.GetSearchResults("betta fish", 20, 4, proxyOptions, SearchOptions.Backlink, FocusedWebsites.Xenforo);
            foreach (var item in searchResults)
            {
                Console.WriteLine("Url:" + item.Url + "Title:" + item.Title);
            }
        }
        [TestMethod]
        public async Task GoogleSearchWithoutProxy_ShouldReturnResults()
        {
            List<GoogleSearchResults.Google.GoogleSearchResult> searchResults = new List<GoogleSearchResults.Google.GoogleSearchResult>();
            var search = new GoogleSearch();
            searchResults = await search.GetSearchResults("betta fish", 20, 4, null, SearchOptions.Backlink, FocusedWebsites.Xenforo);
            foreach (var item in searchResults)
            {
                Console.WriteLine("Url:" + item.Url + "Title:" + item.Title);
            }
        }
    }
}