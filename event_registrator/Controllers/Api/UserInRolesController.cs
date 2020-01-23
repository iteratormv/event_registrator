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
    public class UserInRolesController : ControllerBase
    {
        private readonly EventContext _context;

        public UserInRolesController(EventContext context)
        {
            _context = context;
        }

        // GET: api/UserInRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInRole>>> GetuserInRoles()
        {
            return await _context.userInRoles.ToListAsync();
        }

        // GET: api/UserInRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInRole>> GetUserInRole(int id)
        {
            var userInRole = await _context.userInRoles.FindAsync(id);

            if (userInRole == null)
            {
                return NotFound();
            }

            return userInRole;
        }

        // PUT: api/UserInRoles/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInRole(int id, UserInRole userInRole)
        {
            if (id != userInRole.Id)
            {
                return BadRequest();
            }

            _context.Entry(userInRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInRoleExists(id))
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

        // POST: api/UserInRoles
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UserInRole>> PostUserInRole(UserInRole userInRole)
        {
            _context.userInRoles.Add(userInRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInRole", new { id = userInRole.Id }, userInRole);
        }

        // DELETE: api/UserInRoles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserInRole>> DeleteUserInRole(int id)
        {
            var userInRole = await _context.userInRoles.FindAsync(id);
            if (userInRole == null)
            {
                return NotFound();
            }

            _context.userInRoles.Remove(userInRole);
            await _context.SaveChangesAsync();

            return userInRole;
        }

        private bool UserInRoleExists(int id)
        {
            return _context.userInRoles.Any(e => e.Id == id);
        }
    }
}
