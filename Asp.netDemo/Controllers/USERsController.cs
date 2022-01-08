#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Asp.netDemo.Models;

namespace Asp.netDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class USERsController : ControllerBase
    {
        private readonly UserContext _context;

        public USERsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/USERs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<USER>>> GetuSERs()
        {
            return await _context.uSERs.ToListAsync();
        }

        // GET: api/USERs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<USER>> GetUSER(long id)
        {
            var uSER = await _context.uSERs.FindAsync(id);

            if (uSER == null)
            {
                return NotFound();
            }

            return uSER;
        }

        // PUT: api/USERs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUSER(long id, USER uSER)
        {
            if (id != uSER.Id)
            {
                return BadRequest();
            }

            _context.Entry(uSER).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!USERExists(id))
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

        // POST: api/USERs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<USER>> PostUSER(USER uSER)
        {
            _context.uSERs.Add(uSER);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUSER", new { id = uSER.Id }, uSER);
        }

        // DELETE: api/USERs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUSER(long id)
        {
            var uSER = await _context.uSERs.FindAsync(id);
            if (uSER == null)
            {
                return NotFound();
            }

            _context.uSERs.Remove(uSER);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool USERExists(long id)
        {
            return _context.uSERs.Any(e => e.Id == id);
        }
    }
}
