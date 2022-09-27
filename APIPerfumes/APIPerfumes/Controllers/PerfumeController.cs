using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPerfumes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerfumeController : ControllerBase
    {

        #region Ligação contexto — controlador
        private PerfumeContext _context;

        public PerfumeController(PerfumeContext context)
        {
            _context = context;
        }
        #endregion


        #region Create
        [HttpPost]
        public IActionResult AdicionaPerfume([FromBody] Perfume perfume)
        {
            _context.Perfumes.Add(perfume); 
            _context.SaveChanges(); 
            return CreatedAtAction(nameof(RecuperaPerfumesPorId), new { id = perfume.Id }, perfume);
        }
        #endregion


        #region Read
        [HttpGet]
        [HttpGet]
        public IEnumerable<Perfume> RecuperaPerfumes()
        {
            Console.WriteLine($"No momento, há {_context.Perfumes.Count()} perfumes no banco de dados");
            return _context.Perfumes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaPerfumesPorId(string id)
        {
            // Recupera filme por ID no banco de dados
            Perfume perfume = _context.Perfumes.FirstOrDefault(perfume => perfume.Id == id);

            if (perfume != null)
            {
                return Ok(perfume);
            }

            return NotFound();
        }
        #endregion


        #region Update
        [HttpPut("{id}")]
        public IActionResult AtualizaPerfume(string id, [FromBody] Perfume perfumeNovo)
        {
            Perfume perfume = _context.Perfumes.FirstOrDefault(perfume => perfume.Id == id);

            if (perfume == null) return NotFound();

            perfume.Marca = perfumeNovo.Marca;
            perfume.Nome = perfumeNovo.Nome;
            perfume.Genero = perfumeNovo.Genero;
            perfume.VolumeEmMl = perfumeNovo.VolumeEmMl;
            _context.SaveChanges();
            return NoContent();
        }
        #endregion


        #region Delete
        [HttpDelete("{id}")]
        public IActionResult DeletePerfume(string id)
        {
            Perfume perfume = _context.Perfumes.FirstOrDefault(perfume => perfume.Id == id);

            if (perfume == null) return NotFound();

            _context.Remove(perfume);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion

    }
}
