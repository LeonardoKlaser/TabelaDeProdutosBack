using APIweb.Data;
using APIweb.Models;
using APIweb.ViewModel;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;

namespace APIweb.Controllers
{   
 [ApiController]
 [Route("Api/produtos")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IValidator<Produto> _validator;
        

        // Construtor que injeta o repositório de produtos
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            
        }

        // Método para adicionar um novo produto
        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel productView)
        {
            // Convertendo as datas para UTC
            var dataEmbarqueUtc = DateTime.SpecifyKind(productView.DataEmbarque, DateTimeKind.Utc);
            var dataChegadaUtc = DateTime.SpecifyKind(productView.DataChegada, DateTimeKind.Utc);

            var product = new Produto(
                productView.NomeProduto,
                productView.PaisDeOrigem,
                productView.PaisDeDestino,
                productView.Quantidade,
                productView.ValorUnitario,
                productView.Importador,
                productView.Exportador,
                dataEmbarqueUtc,
                dataChegadaUtc,
                productView.FreteModo
            );


            // Chama o método Add do repositório para adicionar o produto
            await _productRepository.Add(product);

            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            var products = await _productRepository.Get();

            
            return Ok(products);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetID(Guid id)
        {
            
            var products = await _productRepository.GetById(id);

            // Se o produto não for encontrado, retorna NotFound
            if (products == null)
            {
                return NotFound();
            }

            
            return Ok(products);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            // Obtém todos os produtos 
            var produtos = await _productRepository.Get();

            // Encontra o primeiro produto 
            var produto = produtos.FirstOrDefault();

            // Se o produto não for encontrado, retorna NotFound
            if (produto == null)
            {
                return NotFound();
            }

            // Chama o método Delete do repositório para deletar o produto pelo ID
            await _productRepository.Delete(id);

            
            return NoContent();
        }

        // Método para atualizar um produto por ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, ProductViewModel productView)
        {
            var produtoAtualizado = new Produto(
                productView.NomeProduto,
                productView.PaisDeOrigem,
                productView.PaisDeDestino,
                productView.Quantidade,
                productView.ValorUnitario,
                productView.Importador,
                productView.Exportador,
                productView.DataEmbarque.ToUniversalTime(), // Converte a data de embarque para UTC
                productView.DataChegada.ToUniversalTime(), // Converte a data de chegada para UTC
                productView.FreteModo
            );

            // Chama o método Update do repositório para atualizar o produto pelo ID
            await _productRepository.Update(id, produtoAtualizado);

            return NoContent();
        }
    }
}

