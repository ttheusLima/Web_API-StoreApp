using Microsoft.AspNetCore.Mvc;
using StoreApp.Entities;

namespace StoreApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        List<Produto> _produtos = new List<Produto>();

        public ProdutoController() { }
        public ProdutoController(List<Produto> produtos)
        {
            _produtos = produtos;
        }

        public List<Produto> Get_produtos()
        {
            return _produtos;
        }

        [HttpGet]
        public async Task<IEnumerable<Produto>> GetTodosProdutosAsync()
        {
            return await Task.FromResult(Get_produtos());
        }

        public IActionResult GetProdutoId(int id)
        {
            var produto =  _produtos.FirstOrDefault(p => p.IdProduto == id);

            return produto is null ? NotFound() : Ok(produto);
        }

        public async Task<IActionResult> GetProdutoId_Async(int id)
        {
            return await Task.FromResult(GetProdutoId(id));
        }
    }
}