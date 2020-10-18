namespace PlannerAppClient.Models
{
    public class PlanCollectionPagingResponse : BaseAPIResponse
    {
        public Plan[] Records { get; set; }
        
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int? NextPqge { get; set; }

        public int Count { get; set; }

    }
}

