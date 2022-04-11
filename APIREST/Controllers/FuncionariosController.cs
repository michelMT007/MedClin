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
    public class FuncionariosController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public FuncionariosController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Funcionarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionarios()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        ////// GET: api/Funcionarios
        ////[HttpGet("profisao")]
        ////public async Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionarios(String prof)
        ////{
        ////    prof = "Medico";
        ////    //return await _context.Pacientes.Where((pacientes) => pacientes.Nome.Contains(nome+"%")).ToListAsync()
        ////    return await _context.Funcionarios.Where((medico) => medico.profissao.Contains(prof)).ToListAsync();
        ////}
        ////
        
        // GET: api/Funcionarios
        [HttpGet("lstmedicos")]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetMedicos()
        {
            return await _context.Funcionarios.Where((med) => med.profissao.Equals("Médico")).ToListAsync();
        }

        // GET: api/Funcionarios
        [HttpGet("lstatendentes")]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetAtendentes()
        {
            return await _context.Funcionarios.Where((med) => med.profissao.Equals("Atendente")).ToListAsync();
        }
        // GET: api/Funcionarios

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Funcionario>>> GetMedico()
        //{ 
        //    return await _context.Funcionarios.Where((funcionario) => funcionario.profissao.Contains("Medico%")).ToListAsync(); ;
        //}

        //// GET: api/Funcionarios

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Funcionario>>> GetAtendente()
        //{
        //    return await _context.Funcionarios.Where((funcionario) => funcionario.profissao.Contains("Atendente%")).ToListAsync(); 
        //}

        // GET: api/Funcionarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionario>> GetFuncionario(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return funcionario;
        }

        // PUT: api/Funcionarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncionario(int id, Funcionario funcionario)
        {
            if (id != funcionario.Id)
            {
                return BadRequest();
            }

            _context.Entry(funcionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionarioExists(id))
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

        // POST: api/Funcionarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Funcionario>> PostFuncionario(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFuncionario", new { id = funcionario.Id }, funcionario);
        }

        // DELETE: api/Funcionarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionario(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionarios.Any(e => e.Id == id);
        }
    }
}
