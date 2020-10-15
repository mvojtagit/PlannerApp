namespace PlannerAppClient.Models
{
    public abstract class BaseAPIResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}

