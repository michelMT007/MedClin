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
    public class AtendimentosController : ControllerBase
    {
        private readonly ApplicationContext _context;
        
        public AtendimentosController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Pacientes
        [HttpGet("atendimentos/{nome}")]
        public async Task<ActionResult<IEnumerable<Atendimento>>> GetPacienteNome(String nome)
        {
            var resultado = await _context.Atendimentos.Where((p) => p.NomeMedico.Contains(nome)).ToListAsync();
            if (resultado == null)
            {
                return NotFound();
            }
            return resultado;
        }

        // GET: api/Atendimentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atendimento>>> GetAtendimentos()
        {
            return await _context.Atendimentos.ToListAsync();
        }

        //// GET: api/Funcionarios
        //[HttpGet("{id}")]
        //public async Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionario(int id)
        //{
        //    return await _context.Funcionarios.ToListAsync();
        //}

        //// GET: api/Procedimentos
        //[HttpGet("{id}")]
        //public async Task<ActionResult<IEnumerable<Procedimento>>> GetProcedimento(int id)
        //{
        //    return await _context.Procedimentos.ToListAsync();
        //}

        //// GET: api/Pacientes
        //[HttpGet("{id}")]
        //public async Task<ActionResult<IEnumerable<Paciente>>> GetPaciente(int id)
        //{
        //    return await _context.Pacientes.ToListAsync();
        //}

        // api/Atendimentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Atendimento>> GetAtendimento(int id)
        {
            var atendimento = await _context.Atendimentos.FindAsync(id);
            if (atendimento == null)
            {
                return NotFound();
            }
            return atendimento;
        }

        // PUT: api/Atendimentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtendimento(int id, Atendimento atendimento)
        {
            if (id != atendimento.Id)
            {
                return BadRequest();
            }

            _context.Entry(atendimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtendimentoExists(id))
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

        // POST: api/Atendimentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Atendimento>> PostAtendimento(Atendimento atendimento)
        {
            _context.Atendimentos.Add(atendimento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAtendimento", new { id = atendimento.Id }, atendimento);
        }

        // DELETE: api/Atendimentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtendimento(int id)
        {
            var atendimento = await _context.Atendimentos.FindAsync(id);
            if (atendimento == null)
            {
                return NotFound();
            }

            _context.Atendimentos.Remove(atendimento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AtendimentoExists(int id)
        {
            return _context.Atendimentos.Any(e => e.Id == id);
        }
    }
}
