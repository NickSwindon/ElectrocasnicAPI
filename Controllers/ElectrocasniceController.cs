using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectrocasniceController : ControllerBase
    {
        private readonly DBContext _context;

        public ElectrocasniceController(DBContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Electrocasnice>>> GetElectrocasnice()
        {
            return await _context.Electrocasnice.ToListAsync();
        }

     
        [HttpGet("{id}")]
        public async Task<ActionResult<Electrocasnice>> GetElectrocasnice(int id)
        {
            var electrocasnice = await _context.Electrocasnice.FindAsync(id);

            if (electrocasnice == null)
            {
                return NotFound();
            }

            return electrocasnice;
        }

       
       
        [HttpPost]
        public async Task<ActionResult<Electrocasnice>> PostElectrocasnice(Electrocasnice electrocasnice)
        {
            _context.Electrocasnice.Add(electrocasnice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElectrocasnice", new { id = electrocasnice.Id }, electrocasnice);
        }

       
        [HttpDelete("{id}")]
        public async Task<ActionResult<Electrocasnice>> DeleteElectrocasnice(int id)
        {
            var electrocasnice = await _context.Electrocasnice.FindAsync(id);
            if (electrocasnice == null)
            {
                return NotFound();
            }

            _context.Electrocasnice.Remove(electrocasnice);
            await _context.SaveChangesAsync();

            return electrocasnice;
        }

    }
}
