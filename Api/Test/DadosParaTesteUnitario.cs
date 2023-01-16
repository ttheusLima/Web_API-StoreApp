using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Entities;

namespace Test
{
    public class DadosParaTesteUnitario
    {
        public List<Produto> GetTestProdutos()
        {
            var testProdutos = new List<Produto>();
            testProdutos.Add(new Produto { IdProduto = 1, Nome = "Demo1", Preco = 1 });
            testProdutos.Add(new Produto { IdProduto = 2, Nome = "Demo2", Preco = 3.75M });
            testProdutos.Add(new Produto { IdProduto = 3, Nome = "Demo3", Preco = 16.99M });
            testProdutos.Add(new Produto { IdProduto = 4, Nome = "Demo4", Preco = 11.00M });

            return testProdutos;
        }
    }
}