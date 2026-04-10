using DeliveryAPI.Context;
using DeliveryAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeliveryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly DeliveryDbContext _context;

        public CategoriasController(DeliveryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return _context.Categorias.AsNoTracking().ToList();
            //AsNoTracking serve para que essa ação GET não seja rastreada
            //isso melhora performance
        }

        [HttpGet("{id:int}", Name ="ObterCategoria")]
        public ActionResult Get( int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);

            if (categoria is null)
            {
                return BadRequest("Categoria não encontrado!");
            }

            return Ok(categoria);
        }

        [HttpGet("produto")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriaProduto()
        {
            /*
             Include serve para que quando for mostrar a categoria, tambem mostre os produtos dela
             porem nunca podemos retornar todas as categorias , imagine em um sistema gigante isso 
             sera ruim para performance, portanto o certo é aplicar um filtro, usando WHERE por exemplo.
             */
            return _context.Categorias.Include(p => p.Produtos).Where(c => c.CategoriaId <= 10).ToList();
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if(categoria is null)
            {
                return BadRequest();
            }

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if(id != categoria.CategoriaId)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);

            if(categoria is null)
            {
                return BadRequest();
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return Ok(categoria);
        }
    }
}
