using GoogleSearchResults.Checker;
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
                Console.WriteLine("Url:" + item.URL + "Title:" + item.Title);
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
                Console.WriteLine("Url:" + item.URL + "Title:" + item.Title);
            }
        }
        [TestMethod]
        public async Task Checker_ShouldReturnResults()
        {
            List<GoogleSearchResults.Google.GoogleSearchResult> searchResults = new List<GoogleSearchResults.Google.GoogleSearchResult>();
            List<GoogleSearchResults.Checker.CheckerResults> results = new List<CheckerResults>();
            var search = new GoogleSearch();
            searchResults = await search.GetSearchResults("betta fish", 20, 4, null, SearchOptions.Backlink, FocusedWebsites.Xenforo);
            Checker checker = new Checker();
            results = await checker.CheckAsync(searchResults);
            foreach (var item in results)
            {
                Console.WriteLine($"URL: {item.URL}  Title: {item.Title} DA: {item.DA} PA: {item.PA} Spam Score: {item.SpamScore} IP: {item.IP}");
            }
        }
        [TestMethod]
        public async Task CheckerWithProxy_ShouldReturnResults()
        {
            var proxyOptions = new ProxyOptions()
            {
                UseProxy = true,
                IP = "IP",
                Port = "PORT",
                Username = "USERNAME",
                Password = "PASSWORD",
            };
            List<GoogleSearchResults.Google.GoogleSearchResult> searchResults = new List<GoogleSearchResults.Google.GoogleSearchResult>();
            List<GoogleSearchResults.Checker.CheckerResults> results = new List<CheckerResults>();
            var search = new GoogleSearch();
            searchResults = await search.GetSearchResults("betta fish", 20, 4, null, SearchOptions.Backlink, FocusedWebsites.Xenforo);
            Checker checker = new Checker();
            results = await checker.CheckAsync(searchResults);
            foreach (var item in results)
            {
                Console.WriteLine($"URL: {item.URL}  Title: {item.Title} DA: {item.DA} PA: {item.PA} Spam Score: {item.SpamScore} IP: {item.IP}");
            }
        }
    }
}