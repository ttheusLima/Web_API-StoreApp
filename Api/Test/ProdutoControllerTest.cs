using Microsoft.AspNetCore.Mvc;
using StoreApp.Controllers;
using StoreApp.Entities;

namespace Test;

public class ProdutoControllerTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GetTodosProdutos_DeverarRetonarTodosProdutos()
    {
        var testProdutos = new DadosParaTesteUnitario().GetTestProdutos();
        var controller = new ProdutoController(testProdutos);

        var result =  controller.Get_produtos() as List<Produto>;

        Assert.AreEqual(testProdutos.Count(), result.Count());
    }

    [Test]
    public async Task GetTodosProdutosAsyn_DeverarRetonarTodosProdutosAsync()
    {
        var testProdutos = new DadosParaTesteUnitario().GetTestProdutos();
        var controller = new ProdutoController(testProdutos);

        var result = await controller.GetTodosProdutosAsync() as List<Produto>;

        Assert.AreEqual(testProdutos.Count(), result.Count());
    }

    [Test]
    public void GetProdutoPortId_DeverarRetonarCorretoProduto()
    {
        var testProdutos = new DadosParaTesteUnitario().GetTestProdutos();
        var controller = new ProdutoController(testProdutos);

        var okResult = controller.GetProdutoId(4) as OkObjectResult;
        var valorDoObjetoDeProduto = (Produto) okResult.Value;
        
        Assert.IsNotNull(okResult);
        Assert.AreEqual(testProdutos[3].Nome, valorDoObjetoDeProduto.Nome);
    }

    [Test]
    public async Task GetProdutoPortIdAsync_DeverarRetonarCorretoProdutoAsync()
    {
        var testProdutos = new DadosParaTesteUnitario().GetTestProdutos();
        var controller = new ProdutoController(testProdutos);

        var okResult = await controller.GetProdutoId_Async(3) as OkObjectResult;
        var valorDoObjetoDeProduto = (Produto) okResult.Value;

        Assert.IsNotNull(okResult);
        Assert.AreEqual(testProdutos[2].Nome, valorDoObjetoDeProduto.Nome);
    }

    [Test]
    public void GetProdutoId_DeverarNaoEncontrarProduto()
    {
        var controller = new ProdutoController(new DadosParaTesteUnitario().GetTestProdutos());

        var result = controller.GetProdutoId(999) as NotFoundResult;
        
        Assert.IsInstanceOf<NotFoundResult>(result);
    }
}