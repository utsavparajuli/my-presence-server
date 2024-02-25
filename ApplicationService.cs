using MyPresence.Server.Models;

namespace MyPresence.Server
{
    public class ApplicationService : IDatabaseService
    {
        private readonly MyDbContext _context;

        public ApplicationService(MyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Application> GetApplications(int userId)
        {
            // Implement logic to query the database and retrieve applications for the specified user
            //return _context.Applications.Where(a => a.UserId == userId).ToList();

            // Dummy data
            var dummyApplications = new List<Application>
            {
                new Application(1, userId, "Dummy Company 1", "Pending", DateTime.Now, "http://dummy-url.com"),
                new Application(2, userId, "Dummy Company 2", "Approved", DateTime.Now.AddDays(-2), "http://dummy-url.com"),
                new Application(3, userId, "Dummy Company 3", "Rejected", DateTime.Now.AddDays(-5), "http://dummy-url.com")
                // Add more dummy data as needed
            };

            return dummyApplications;
        }

        // Implement other methods as needed
    }

}
