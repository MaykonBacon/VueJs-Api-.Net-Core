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

    
    public class FilmesController : ControllerBase
    {
        private readonly AplicacaoDbContext _context;

        public FilmesController (AplicacaoDbContext context) 
        {
            _context = context;
        }

        //Listar Filmes
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listaFilmes = await _context.Filmes.ToListAsync();
                return Ok(listaFilmes);
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
            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null)
            {
                return NotFound();
            }
            return Ok(filme);
        }

        //Incluir Filmes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Filme filmes)
        {
            try
            {
                _context.Filmes.Add(filmes);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Filme foi registrado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        //Atualizar Filmes
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Filme filmes)
        {
            try
            {
                if (id != filmes.Id)
                {
                    return NotFound();
                }
                _context.Filmes.Update(filmes);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Filme atualizado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Excluir Filmes
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var filmes = await _context.Filmes.FindAsync(id);
                if (filmes == null)
                {
                    return NotFound();
                }
                _context.Filmes.Remove(filmes);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Filme excluído com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
