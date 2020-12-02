using Backend_Api.Context;
using Backend_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocadoraController : ControllerBase
    {
        private readonly AplicacaoDbContext _context;
        public LocadoraController(AplicacaoDbContext context)
        {
            _context = context;
        }
        // GET: api/<LocadoraController>
        //Retorna a lista de locadoras
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listaLocadoras = await _context.Locadoras.ToListAsync();
                return Ok(listaLocadoras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Listar por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> get(int id)
        {
            var locadora = await _context.Locadoras.FindAsync(id);
            if(locadora == null)
            {
                return NotFound();
            }
            return Ok(locadora);
        }

        //Incluir locadoras
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Locadora locadora)
        {
            try
            {
                _context.Locadoras.Add(locadora);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Locadora foi registrada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Atualizar locadoras
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Locadora locadora)
        {
            try
            {
                if (id != locadora.Id)
                {
                    return NotFound();
                }
                _context.Locadoras.Update(locadora);
                await _context.SaveChangesAsync();
                return Ok(new { message = "A locadora foi atualizada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Excluir Locadoras
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var locadora = await _context.Locadoras.FindAsync(id);
                if (locadora == null)
                {
                    return NotFound();
                }
                _context.Locadoras.Remove(locadora);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Locadora excluída com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
