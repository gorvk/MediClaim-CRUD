using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDemo.Model;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediClaimsController : ControllerBase
    {
        private readonly ClaimManagementContext _context;

        public MediClaimsController(ClaimManagementContext context)
        {
            _context = context;
        }

        // GET: api/MediClaims
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediClaim>>> GetMediClaims()
        {
          if (_context.MediClaims == null)
          {
              return NotFound();
          }
            return await _context.MediClaims.ToListAsync();
        }

        // GET: api/MediClaims/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MediClaim>> GetMediClaim(int id)
        {
          if (_context.MediClaims == null)
          {
              return NotFound();
          }
            var mediClaim = await _context.MediClaims.FindAsync(id);

            if (mediClaim == null)
            {
                return NotFound();
            }

            return mediClaim;
        }

        // PUT: api/MediClaims/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMediClaim(int id, MediClaim mediClaim)
        {
            if (id != mediClaim.Id)
            {
                return BadRequest();
            }

            _context.Entry(mediClaim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediClaimExists(id))
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

        // POST: api/MediClaims
        [HttpPost]
        public async Task<ActionResult<MediClaim>> PostMediClaim(MediClaim mediClaim)
        {
          if (_context.MediClaims == null)
          {
              return Problem("Entity set 'ClaimManagementContext.MediClaims'  is null.");
          }
            _context.MediClaims.Add(mediClaim);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MediClaimExists(mediClaim.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMediClaim", new { id = mediClaim.Id }, mediClaim);
        }

        // DELETE: api/MediClaims/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMediClaim(int id)
        {
            if (_context.MediClaims == null)
            {
                return NotFound();
            }
            var mediClaim = await _context.MediClaims.FindAsync(id);
            if (mediClaim == null)
            {
                return NotFound();
            }

            _context.MediClaims.Remove(mediClaim);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MediClaimExists(int id)
        {
            return (_context.MediClaims?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
