using MyPresence.Server.Models;

namespace MyPresence.Server
{
    public interface IDatabaseService
    {
        IEnumerable<Application> GetApplications(int userId);
    }
}
