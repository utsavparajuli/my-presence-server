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
            var applications = _context.applications.FromSqlRaw("SELECT * FROM applications WHERE user_id = {0}", userId).ToList();
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

        public bool ApplicationExists(int id)
        {
            return _context.applications.Any(e => e.id == id);
        }
    }

}
