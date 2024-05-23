using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pubs.Models;
using pubs.Models.Dto;

namespace pubs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly pubsContext _context;

        public AuthorsController(pubsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<authorsDto>>> GetAuthorsAll()
        {
            if (_context.authors == null)
            {
                return NotFound();
            }
            return await _context.authors
                .Select(author => new authorsDto()
                {
                    ID = author.au_id,
                    Phone = author.phone,
                    Address = author.address,
                    City = author.city,
                    State = author.state
                }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<authorsDto>> GetAuthors(string id)
        {
            if (_context.authors == null)
            {
                return NotFound();
            }

            var author = await _context.authors.FirstOrDefaultAsync(p => p.au_id == id);

            if (author == null)
            {
                return NotFound();
            }

            return new authorsDto()
            {
                ID = author.au_id,
                Phone = author.phone,
                Address = author.address,
                City = author.city,
                State = author.state
            };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(string id, authors author)
        {
            if (id != author.au_id)
            {
                return BadRequest();
            }

            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
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

        [HttpPost]
        public async Task<ActionResult<authors>> PostAuthor(authors authors)
        {
            if (_context.authors == null)
            {
                return Problem("Entity set 'authors'  is null.");
            }
            _context.authors.Add(authors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthors", new { id = authors.au_id }, authors);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(string id)
        {
            if (_context.authors == null)
            {
                return NotFound();
            }
            var author = await _context.authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _context.authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorExists(string id)
        {
            return (_context.authors?.Any(e => e.au_id.Equals(id))).GetValueOrDefault();
        }
    }
}
