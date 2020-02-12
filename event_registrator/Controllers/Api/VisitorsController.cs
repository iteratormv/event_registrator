using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using event_registrator.Data;
using event_registrator.Models;

namespace event_registrator.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorsController : ControllerBase
    {
        private readonly EventContext _context;

        public VisitorsController(EventContext context)
        {
            _context = context;
        }

        // GET: api/Visitors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visitor>>> Getvisitors()
        {
            return await _context.visitors.ToListAsync();
        }

        // GET: api/Visitors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Visitor>> GetVisitor(int id)
        {
            var visitor = await _context.visitors.FindAsync(id);

            if (visitor == null)
            {
                return NotFound();
            }

            return visitor;
        }

        // PUT: api/Visitors/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisitor(int id, Visitor visitor)
        {
            if (id != visitor.Id)
            {
                return BadRequest();
            }

            _context.Entry(visitor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitorExists(id))
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

        // POST: api/Visitors
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Visitor>> PostVisitor(Visitor visitor)
        {
            _context.visitors.Add(visitor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVisitor", new { id = visitor.Id }, visitor);
        }

        // DELETE: api/Visitors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Visitor>> DeleteVisitor(int id)
        {
            var visitor = await _context.visitors.FindAsync(id);
            if (visitor == null)
            {
                return NotFound();
            }

            _context.visitors.Remove(visitor);
            await _context.SaveChangesAsync();

            return visitor;
        }

        private bool VisitorExists(int id)
        {
            return _context.visitors.Any(e => e.Id == id);
        }
    }
}
