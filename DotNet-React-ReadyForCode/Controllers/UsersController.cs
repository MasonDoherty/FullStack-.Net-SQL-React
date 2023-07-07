using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNet_React_ReadyForCode.Models;

namespace DotNet_React_ReadyForCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpsController : ControllerBase
    {
        private readonly DbContext _context;

        public SignUpsController(DbContext context)
        {
            _context = context;
        }

        // GET: api/SignUps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetSignUp()
        {
          if (_context.SignUp == null)
          {
              return NotFound();
          }
            return await _context.SignUp.ToListAsync();
        }

        // GET: api/SignUps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetSignUp(int id)
        {
          if (_context.SignUp == null)
          {
              return NotFound();
          }
            var signUp = await _context.SignUp.FindAsync(id);

            if (signUp == null)
            {
                return NotFound();
            }

            return signUp;
        }

        // PUT: api/SignUps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSignUp(int id, User signUp)
        {
            if (id != signUp.Id)
            {
                return BadRequest();
            }

            _context.Entry(signUp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SignUpExists(id))
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

        // POST: api/SignUps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostSignUp(User signUp)
        {
          if (_context.SignUp == null)
          {
              return Problem("Entity set 'DbContext.SignUp'  is null.");
          }
            _context.SignUp.Add(signUp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSignUp", new { id = signUp.Id }, signUp);
        }

        // DELETE: api/SignUps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSignUp(int id)
        {
            if (_context.SignUp == null)
            {
                return NotFound();
            }
            var signUp = await _context.SignUp.FindAsync(id);
            if (signUp == null)
            {
                return NotFound();
            }

            _context.SignUp.Remove(signUp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SignUpExists(int id)
        {
            return (_context.SignUp?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
