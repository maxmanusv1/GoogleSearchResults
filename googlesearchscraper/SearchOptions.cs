using GoogleSearchResults;

namespace GoogleSearchResults
{
    public enum SearchOptions
    {
        /// <summary>
        /// Gets all results pointed to specifed query.
        /// </summary>
        Normal,
        /// <summary>
        /// Returns forum websites with query word you provided.
        /// </summary>
        Forum,
        /// <summary>
        /// It points to related web sites & forums to scrap results.
        /// </summary>
        Backlink,
        /// <summary>
        /// Google will return pages that contain the query word you provided.
        /// </summary>
        INTEXT,
        /// <summary>
        /// Google will only show you pages that have that term in the URL
        /// </summary>
        INURL,
        /// <summary>
        /// Google will return definitions for the term from different sites. 
        /// </summary>
        DEFINE,
        /// <summary>
        /// Google will return related websites.
        /// </summary>
        RELATED
    }
}
