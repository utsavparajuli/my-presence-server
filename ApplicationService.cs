using Microsoft.EntityFrameworkCore;
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
            //return _context.applications.Where(a => a.user_id == userId).ToList();
            // Implement logic to query the database and retrieve applications for the specified user
            //return _context.Applications.Where(a => a.UserId == userId).ToList();

            // Dummy data
            //var dummyApplications = new List<Application>
            //{
            //    new Application(1, userId, "Dummy Company 1", "Pending", DateTime.Now, "http://dummy-url.com"),
            //    new Application(2, userId, "Dummy Company 2", "Approved", DateTime.Now.AddDays(-2), "http://dummy-url.com"),
            //    new Application(3, userId, "Dummy Company 3", "Rejected", DateTime.Now.AddDays(-5), "http://dummy-url.com")
            //    // Add more dummy data as needed
            //};

            //return dummyApplications;
            Console.WriteLine("Inside the getapps");
            var applications = _context.applications.FromSqlRaw("SELECT * FROM applications WHERE user_id = {0}", userId).ToList();
            Console.WriteLine(applications);
            return applications;

        }

        public Application GetApplicationById(int applicationId)
        {
            return _context.applications.FirstOrDefault(a => a.id == applicationId);


        }

        public void AddApplication(Application application)
        {
            _context.applications.Add(application);
            _context.SaveChanges();
        }

        public void UpdateApplication(Application application)
        {
            _context.applications.Update(application);
            _context.SaveChanges();
        }

        public void DeleteApplication(int applicationId)
        {
            var application = _context.applications.FirstOrDefault(a => a.id == applicationId);
            if (application != null)
            {
                _context.applications.Remove(application);
                _context.SaveChanges();
            }
        }

        // Implement other methods as needed
    }

}
