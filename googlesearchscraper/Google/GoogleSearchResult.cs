using GoogleSearchResults;

namespace GoogleSearchResults.Google
{
    /// <summary>
    /// Search results from Google.
    /// </summary>
    public class GoogleSearchResult 
    {
        public required string Url { get; set; }
        public required string Title { get; set; }
    }
}
