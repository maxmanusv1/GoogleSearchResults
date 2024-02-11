using GoogleSearchResults;

namespace GoogleSearchResults.Google
{
    /// <summary>
    /// Search results from Google.
    /// </summary>
    public class GoogleSearchResult : ISearchResult
    {
        public string URL { get; set; }
        public string Title { get; set; }
    }
}
