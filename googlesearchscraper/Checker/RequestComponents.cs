
using GoogleSearchResults.Google;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoogleSearchResults.Checker
{
    internal class RequestComponents
    {
        string payload = "website_name={replace}&da=y&pa=y&ss=y&ip=y&page_token=get_website&mng_t=0&mng_2_api_urls=https://thefashionhubs.com/wp-content/plugins/mng_bulk_domain_authority_api_v3/api.php";
        public async Task<string> CreatePayload(List<GoogleSearchResult> searchList)
        {
            string links = string.Empty;
            foreach (var item in searchList)
                links += item + "\n";
            return payload.Replace("{replace}",links);
        }
    }   
  
}
