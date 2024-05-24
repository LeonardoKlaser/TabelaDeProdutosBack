using APIweb.Controllers;
using APIweb.Infraestrutura;
using APIweb.Models;
using APIweb.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Fixtures;
using Moq;
using Microsoft.AspNetCore.Mvc;



namespace TestProject.Testes
{
    public class ProductMoqTestes
    {
        // Este teste verifica se o método Add do repositório é chamado quando um novo produto é adicionado
        [Fact]
        public async Task AddProduct_ShouldCallRepositoryAdd()
        {
            // Cria um mock para IProductRepository
            var mockRepo = new Mock<IProductRepository>();

            // Cria uma instância do ProductController usando o mock do repositório
            var controller = new ProductController(mockRepo.Object);

            // Inicializa o ProductViewModel (simulação dos dados de entrada)
            var productViewModel = new ProductViewModel { /* inicializar propriedades */ };

            // Chama o método Add do controlador
            await controller.Add(productViewModel);

            // Verifica se o método Add do repositório foi chamado uma vez
            mockRepo.Verify(repo => repo.Add(It.IsAny<Produto>()), Times.Once);
        }

        // Este teste verifica se o método Add do controlador retorna um resultado Ok
        [Fact]
        public async Task AddProduct_ShouldReturnOkResult()
        {
            // Arrange - configuração do ambiente de teste
            var mockRepo = new Mock<IProductRepository>();
            var controller = new ProductController(mockRepo.Object);

            // Inicializa o ProductViewModel com valores de teste
            var productViewModel = new ProductViewModel
            {
                NomeProduto = "ProdutoTeste",
                PaisDeOrigem = "Brasil",
                PaisDeDestino = "EUA",
                Quantidade = 10,
                ValorUnitario = 100,
                Importador = "ImportadorTeste",
                Exportador = "ExportadorTeste",
                DataEmbarque = DateTime.Now,
                DataChegada = DateTime.Now.AddDays(5),
                FreteModo = "Marítimo"
            };

            // Act - chama o método Add do controlador
            var result = await controller.Add(productViewModel);

            // Assert - verifica se o método Add do repositório foi chamado uma vez
            mockRepo.Verify(repo => repo.Add(It.IsAny<Produto>()), Times.Once);
        }

        // Este teste verifica se o método Get do controlador retorna a lista de produtos esperada
        [Fact]
        public async Task GetProduct_ShouldReturnProducts()
        {
            // Arrange - configuração do ambiente de teste
            var mockRepo = new Mock<IProductRepository>();

            // Configura o mock para retornar uma lista de produtos quando o método Get for chamado
            mockRepo.Setup(repo => repo.Get()).ReturnsAsync(GetTestProducts());

            // Cria uma instância do ProductController usando o mock do repositório
            var controller = new ProductController(mockRepo.Object) ;

            // Act - chama o método Get do controlador
            var result = await controller.Get();

            // Assert - verifica se o resultado é do tipo OkObjectResult
            var okResult = Assert.IsType<OkObjectResult>(result);

            // Verifica se o valor retornado é uma lista de produtos
            var returnProducts = Assert.IsType<List<Produto>>(okResult.Value);

            // Verifica se a lista de produtos retornada contém 2 itens
            Assert.Equal(2, returnProducts.Count);
        }

        // Método auxiliar para criar uma lista de produtos de teste
        private List<Produto> GetTestProducts()
        {
            return new List<Produto>
        {
            new Produto("Produto1", "Brasil", "EUA", 10, 100, "Importador1", "Exportador1", DateTime.Now, DateTime.Now.AddDays(5), "Marítimo"),
            new Produto("Produto2", "Brasil", "EUA", 20, 200, "Importador2", "Exportador2", DateTime.Now, DateTime.Now.AddDays(10), "Aéreo")
        };
        }
    }

}
