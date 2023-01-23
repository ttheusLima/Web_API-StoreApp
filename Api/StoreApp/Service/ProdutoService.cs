using Microsoft.AspNetCore.Mvc;
using StoreApp.Context;
using StoreApp.Entities;
using StoreApp.Interface;

namespace StoreApp.Service
{
    public class ProdutoService : IProdutoService
    {
        public ProdutoService(){ }

        private readonly StoreAppContext _context;

        public ProdutoService(StoreAppContext context)
        {
            _context = context;
        }

        public IActionResult GetProdutoId(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.IdProduto == id); 

            return (IActionResult)produto;
        }

        public List<Produto> Get_produtos()
        {
            return _context.Produtos.ToList();
        }

        public void PostProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }
    }
}