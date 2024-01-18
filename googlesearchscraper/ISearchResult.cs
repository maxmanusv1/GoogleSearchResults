using GoogleSearchResults;

namespace GoogleSearchResults
{
    /// <summary>
    /// Represents an search result. Will be used next version for Yandex/DuckDuckGo and Google Results classes.
    /// </summary>
    public interface ISearchResult
    {
        /// <summary>
        /// Gets URL of the site.
        /// </summary>
        string url { get; }
        /// <summary>
        ///  Gets title of the content.
        /// </summary>
        string title { get; }
    }
}
