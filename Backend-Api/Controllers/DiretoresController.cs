using Backend_Api.Context;
using Backend_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiretoresController : ControllerBase
    {
        private readonly AplicacaoDbContext _context;

        public DiretoresController(AplicacaoDbContext context)
        {
            _context = context;
        }

        //Listar Diretores
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listaDiretores = await _context.Diretores.ToListAsync();
                return Ok(listaDiretores);
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
            var diretores = await _context.Diretores.FindAsync(id);
            if (diretores == null)
            {
                return NotFound();
            }
            return Ok(diretores);
        }

        //Incluir Diretor
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Diretor diretores)
        {
            try
            {
                _context.Diretores.Add(diretores);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Diretor registrado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Editar Diretor
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Diretor diretores)
        {
            try
            {
                if (id != diretores.Id)
                {
                    return NotFound();
                }
                _context.Diretores.Update(diretores);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Diretor atualizado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Excluir Diretores
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var diretores = await _context.Diretores.FindAsync(id);
                if (diretores == null)
                {
                    return NotFound();
                }
                _context.Diretores.Remove(diretores);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Diretor excluído com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
