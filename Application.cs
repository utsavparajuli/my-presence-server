namespace MyPresence.Server
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }

        // Constructor
        public Application(int applicationId, int userId, string companyName, string status, DateTime date, string url)
        {
            ApplicationId = applicationId;
            UserId = userId;
            CompanyName = companyName;
            Status = status;
            Date = date;
            Url = url;
        }

        // Constructor
        public Application(int userId, string companyName, string status, DateTime date, string url)
        {
            UserId = userId;
            CompanyName = companyName;
            Status = status;
            Date = date;
            Url = url;
        }
    }
}
