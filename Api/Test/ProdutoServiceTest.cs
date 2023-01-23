using Microsoft.EntityFrameworkCore;
using Moq;
using StoreApp.Context;
using StoreApp.Entities;
using StoreApp.Interface;
using StoreApp.Service;

namespace Test
{
    public class ProdutoServiceTest
    {
        private Mock<DbSet<Produto>> _dbSet;
        private Mock<StoreAppContext> _context;
        private IProdutoService _repository;

        [SetUp]
        public void Setup()
        {
            var sampleData = new List<Produto>(new DadosParaTesteUnitario().GetTestProdutos()).AsQueryable();
 
            _dbSet = new Mock<DbSet<Produto>>();
            _dbSet.As<IQueryable<Produto>>().Setup(x => x.Provider).Returns(sampleData.Provider);
            _dbSet.As<IQueryable<Produto>>().Setup(x => x.Expression).Returns(sampleData.Expression);
            _dbSet.As<IQueryable<Produto>>().Setup(x => x.ElementType).Returns(sampleData.ElementType);
            _dbSet.As<IQueryable<Produto>>().Setup(x => x.GetEnumerator()).Returns(sampleData.GetEnumerator());
 
            _context = new Mock<StoreAppContext>();
            _context.Setup(x => x.Produtos).Returns(_dbSet.Object);
 
            _repository = new ProdutoService(_context.Object);
        }

        [Test]
        public void PostProduto_DeverarCriarumNovoProduto()
        {
            var simplesProduto = new Produto() { IdProduto = 5, Nome = "Demo1", Preco = 1 };

            _repository.PostProduto(simplesProduto);

            _dbSet.Verify(m => m.Add(It.IsAny<Produto>()), Times.Once);
            _context.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Test]
        public void GetTodosProdutos_DeverarRetonarTodosProdutos()
        {
            var produtos = _repository.Get_produtos() as List<Produto>;

            Assert.IsNotNull(produtos);
            Assert.AreEqual(4, produtos.Count());
        }

    }
}