#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restapi_rocket_elevators.Models;

namespace restapi_rocket_elevators.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterventionController : ControllerBase
    {
        private readonly DataContext _context;

        public InterventionController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Intervention
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Intervention>>> GetInterventions()
        {
            return await _context.Interventions.ToListAsync();
        }

        // GET: api/Intervention/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Intervention>> GetIntervention(long id)
        {
            var intervention = await _context.Interventions.FindAsync(id);

            if (intervention == null)
            {
                return NotFound();
            }

            return intervention;
        }
        [HttpGet("pending")]
        public async Task<ActionResult<IEnumerable<Intervention>>> GetPendingInterventions(long id)
        {
            //  return _context.Elevators.Any(e => e.status == "offline");
            var pendinginterventions = _context.Interventions.Where(p => p.Status == "Pending" && p.StartDatetime == null);
            return await pendinginterventions.ToListAsync();
        }        

       
        // PUT: api/Intervention/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIntervention(long id, Intervention intervention)
        {
            if (id != intervention.Id)
            {
                return BadRequest();
            }

            _context.Entry(intervention).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterventionExists(id))
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
        [HttpPut("{id}/statusandstarttime")]
        public IActionResult PutInprogressStarttime(long id)
        {

            var todointervention = _context.Interventions.First(todointervention => todointervention.Id == id);
            todointervention.Status = "In Progress";
            todointervention.StartDatetime = DateTime.Now;
            _context.SaveChanges();

            return Ok("Changed the Staus to 'In Progress', Starting now!");
        }
        [HttpPut("{id}/statusandendtime")]
        public IActionResult PutCompletedEndtime(long id)
        {

            var doneintervention = _context.Interventions.First(doneintervention => doneintervention.Id == id);
            doneintervention.Status = "Completed";
            doneintervention.EndDatetime = DateTime.Now;
            _context.SaveChanges();

            return Ok("Changed the Staus to 'Compeleted', endtime(coffee time) is now!");
        }


        // POST: api/Intervention
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Intervention>> PostIntervention(Intervention intervention)
        {
            _context.Interventions.Add(intervention);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIntervention", new { id = intervention.Id }, intervention);
        }

        // DELETE: api/Intervention/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIntervention(long id)
        {
            var intervention = await _context.Interventions.FindAsync(id);
            if (intervention == null)
            {
                return NotFound();
            }

            _context.Interventions.Remove(intervention);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InterventionExists(long id)
        {
            return _context.Interventions.Any(e => e.Id == id);
        }
    }
}
