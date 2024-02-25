using System;

namespace MyPresence.Server.Models
{
    public class Application
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string company_name { get; set; }
        public string status { get; set; }
        public DateTime date { get; set; }
        public string url { get; set; }


        // Parameterless constructor
        public Application()
        {
        }

        // Constructor
        public Application(int applicationId, int userId, string companyName, string status, DateTime date, string url)
        {
            id = applicationId;
            user_id = userId;
            company_name = companyName;
            this.status = status;
            this.date = date;
            this.url = url;
        }

        // Constructor
        public Application(int userId, string companyName, string status, DateTime date, string url)
        {
            user_id = userId;
            company_name = companyName;
            this.status = status;
            this.date = date;
            this.url = url;
        }
    }
}
