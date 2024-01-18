using GoogleSearchResults;
using GoogleSearchResults.Google;
namespace GoogleSearchResult.Test
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public async Task GoogleSearch_ShouldReturnResults()
        {
            List<GoogleSearchResults.Google.GoogleSearchResult> searchResults = new List<GoogleSearchResults.Google.GoogleSearchResult>();
            var search = new GoogleSearch();
            searchResults = await search.GetSearchResults("betta fish",20,4,null,SearchOptions.Backlink,FocusedWebsites.Xenforo);
        }
    }
}