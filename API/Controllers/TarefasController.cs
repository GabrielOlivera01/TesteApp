using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ApiContext _context;

        public TarefasController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Tarefas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefas()
        {
          if (_context.Tarefas == null)
          {
              return NotFound();
          }
            return await _context.Tarefas.ToListAsync();
        }

        //GET: api/Tarefas/Concluidas
        [HttpGet("Concluidas")]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetResult()
        {
            if (_context.Tarefas == null)
            {
                return NotFound();
            }
            return await _context.Tarefas.Where(x => x.IsDone).ToListAsync();
        }

        //GET: api/Tarefas/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetTarefa(int id)
        {
            if (_context.Tarefas == null)
            {
                return NotFound();
            }
            
            var tarefa = await _context.Tarefas.FindAsync(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return tarefa;
        }

        // POST: api/Tarefas
        [HttpPost]
        public async Task<ActionResult<Tarefa>> PostTarefa(Tarefa tarefa)
        {
          if (_context.Tarefas == null)
          {
              return Problem("Entity set 'ApiContext.Tarefas'  is null.");
          }
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarefa", new { id = tarefa.Id }, tarefa);
        }

        // PUT: api/Tarefas/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarefa(int id, Tarefa tarefa)
        {
            if (id != tarefa.Id)
            {
                return BadRequest();
            }

            _context.Entry(tarefa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaExists(id))
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

        //PUT: api/Tarefas/ConcluirTarefa/{id}
        [HttpPut("ConcluirTarefa/{id}")]
        public async Task<IActionResult> ConcluirTarefa(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var model = await _context.Tarefas.FindAsync(id);
            if(model is not null)
            {
                model.IsDone = true;
                _context.Update(model);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // DELETE: api/Tarefas/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefa(int id)
        {
            if (_context.Tarefas == null)
            {
                return NotFound();
            }
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TarefaExists(int id)
        {
            return (_context.Tarefas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
       
    }
}
