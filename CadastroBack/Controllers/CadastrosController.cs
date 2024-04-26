using CadastroBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CadastrosController : ControllerBase
    {
        private readonly Contexto _contexto;
        public CadastrosController(Contexto contexto)
        {
            _contexto = contexto;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _contexto.Cadastros.ToListAsync());
        }
        [HttpGet("{cadastroId}")]
        public async Task<ActionResult<Cadastro>> GetById(int cadastroId)
        {
            Cadastro? cadastro = await _contexto.Cadastros.FindAsync(cadastroId);
            if (cadastro != null)
                return Ok(cadastro);

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Post(Cadastro cadastro) 
        {
            await _contexto.AddAsync(cadastro);
            await _contexto.SaveChangesAsync();

            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Put(Cadastro cadastro) 
        {
            _contexto.Update(cadastro);
            await _contexto.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{cadastroId}")]
        public async Task<ActionResult> Delete(int cadastroId) 
        {
            Cadastro? cadastro = await _contexto.Cadastros.FindAsync(cadastroId);
            
            if(cadastro == null)
                return NotFound();
            
            _contexto.Remove(cadastro);
            _contexto.SaveChanges();
            return Ok();
        }
    }
}
