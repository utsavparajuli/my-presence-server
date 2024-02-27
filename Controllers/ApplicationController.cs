using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPresence.Server.Models;

namespace MyPresence.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly ApplicationService _applicationService;


        public ApplicationController(ApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        // GET: api/Apps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplications(int uid)
        {
            Console.WriteLine("Request sent from client");
            var applications = await Task.Run(() => _applicationService.GetApplications(uid));
            return Ok(applications);
            //return await _context.Applications.ToListAsync();
        }

        // GET: api/Apps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Application>> GetApplicationById(int id)
        {
            var application = await Task.Run(() => _applicationService.GetApplicationById(id));

            if (application == null)
            {
                return NotFound();
            }

            return application;
        }

        // PUT: api/Apps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplication(int id, Application application)
        {
            if (id != application.id)
            {
                return BadRequest();
            }

            _context.Entry(application).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Apps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Application>> PostApplication(Application application)
        {
            application.date = application.date.ToUniversalTime();

            _applicationService.AddApplication(application);

            //return CreatedAtAction("GetApplication", new { id = application.ApplicationId }, application);
            return CreatedAtAction(nameof(GetApplicationById), new { id = application.id }, application);

        }

        // DELETE: api/Apps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            var application = await _context.applications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }

            _context.applications.Remove(application);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApplicationExists(int id)
        {
            return _context.applications.Any(e => e.id == id);
        }
    }
}
