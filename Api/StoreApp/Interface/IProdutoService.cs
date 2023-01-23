using Microsoft.AspNetCore.Mvc;
using StoreApp.Entities;

namespace StoreApp.Interface
{
    public interface IProdutoService
    {
        public List<Produto> Get_produtos();
        public Produto GetProdutoId(int id);
        public void PostProduto(Produto produto);
    }
}