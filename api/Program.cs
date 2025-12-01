

namespace ApiProject
{
    // Request and Response DTOs -> data going in and out of the API
    public class SummarizeRequest
    {
        public string Text { get; set; } = string.Empty;
    }

    public class SummarizeResponse
    {
        public string Summary { get; set; } = string.Empty;
    }

    public class Program
    {
        public static void Main(string[] args)
        {
     
        }
    }
}
