using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIREST.Context;
using APIREST.Models;

namespace APIREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedimentosController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ProcedimentosController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Procedimentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Procedimento>>> GetProcedimentos()
        {
            return await _context.Procedimentos.ToListAsync();
        }

        // GET: api/Procedimentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Procedimento>> GetProcedimento(int id)
        {
            var procedimento = await _context.Procedimentos.FindAsync(id);

            if (procedimento == null)
            {
                return NotFound();
            }

            return procedimento;
        }

        // PUT: api/Procedimentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcedimento(int id, Procedimento procedimento)
        {
            if (id != procedimento.Id)
            {
                return BadRequest();
            }

            _context.Entry(procedimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcedimentoExists(id))
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

        // POST: api/Procedimentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Procedimento>> PostProcedimento(Procedimento procedimento)
        {
            _context.Procedimentos.Add(procedimento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProcedimento", new { id = procedimento.Id }, procedimento);
        }

        // DELETE: api/Procedimentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcedimento(int id)
        {
            var procedimento = await _context.Procedimentos.FindAsync(id);
            if (procedimento == null)
            {
                return NotFound();
            }

            _context.Procedimentos.Remove(procedimento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProcedimentoExists(int id)
        {
            return _context.Procedimentos.Any(e => e.Id == id);
        }
    }
}
