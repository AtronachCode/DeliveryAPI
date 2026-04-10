using System.Security.AccessControl;
using DeliveryAPI.Context;
using DeliveryAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        //Injeção do arquivo DbContext //Igual na declaração de atributos em uma classe comum
        private readonly DeliveryDbContext _context;

        //Construtor
        public ProdutosController(DeliveryDbContext context)
        {
            _context = context;
        }

        //Criando o primeiro endpoint GET

        [HttpGet] //Decoro o endpoint para GET
        public ActionResult<IEnumerable<Produto>> Get()//No lugar de IEnumerable também poderia ser usado uma List
        {
            var produtos = _context.Produtos.ToList();
            if (produtos is null)
            {
                NotFound("Produtos não encontrado...");
            }
            return Ok(produtos);
        }


        //Criando o endpoint GET por ID
        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto is null) //Aqui estou verificando se o produto é nulo
            {
                NotFound("Produto não encontrado...");
            }
            return Ok(produto);

        }

        [HttpPost]
        public ActionResult Post(Produto produto) // aqui eu crio um método POST para incluir dados do tipo PRODUTO
        {
            if (produto is null) //Aqui eu verifico se foi informado algum produto
            {
                return BadRequest();
            }

            _context.Produtos.Add(produto);//Aqui eu adiciono o novo produto no contexto do DB
            _context.SaveChanges();//Aqui eu salvo as alterações no banco de dados

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id , Produto produto)
        {
            if(id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            if(produto is null)
            {
                return NotFound("Produto não encontrado!");
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok("Produto Excluido!");
        }
    }
}
