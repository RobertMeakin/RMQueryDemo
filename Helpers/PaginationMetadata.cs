using Newtonsoft.Json;

namespace RMQueryDemo.Helpers
{
    public class PaginationMetadata {

        [JsonProperty("totalRecords")]
        public int? TotalRecords { get; set; }

        [JsonProperty("rpp")]
        public int? Rpp { get; set; }

        [JsonProperty("currentPage")]
        public int? CurrentPage { get; set; }

        [JsonProperty("totalPages")]
        public int? TotalPages { get; set; }

        [JsonProperty("previousPageLink")]
        public string PreviousPageLink { get; set; }

        [JsonProperty("nextPageLink")]
        public string NextPageLink { get; set; }
    }
}