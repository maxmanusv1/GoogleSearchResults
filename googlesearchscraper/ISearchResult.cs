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
        string URL { get; set; }
        /// <summary>
        ///  Gets title of the content.
        /// </summary>
        string Title { get; set; }
    }
}
