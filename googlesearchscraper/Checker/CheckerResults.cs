namespace GoogleSearchResults.Checker
{
    /// <summary>
    /// Results from PA/DA Checker. 
    /// </summary>
    public class CheckerResults : ISearchResult
    {
        /// <summary>
        /// Target website URL.
        /// </summary>
        public string URL { get; set; } 
        /// <summary>
        /// Target website Title. 
        /// </summary>
        public string Title { get; set; }   
        /// <summary>
        /// Domain Authority of target website.
        /// </summary>
        public string? DA {  get; set; }
        /// <summary>
        /// Page Authority of target website.
        /// </summary>
        public string? PA { get; set; }
        /// <summary>
        /// Spam Score of target website.
        /// </summary>
        public string? SpamScore {  get; set; }
        /// <summary>
        /// IP of target website.
        /// </summary>
        public string? IP { get; set; } 
    }
}
