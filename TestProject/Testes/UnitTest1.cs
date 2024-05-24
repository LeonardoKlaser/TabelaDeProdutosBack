using APIweb.Models;

namespace TestProject.Testes
{
    public class UnitTest1
    {
        [Fact]
        public void CriarProduto()
        {
            //Arrange
            var Nome = "Iphone15";
            var Origem = "Brasil";
            var Destino = "China";
            var Quantidade = 50;
            var Valor = 3200;
            var Importador = "Leo";
            var Exportador = "Idata";
            var Embarque = DateTime.Now;
            var Chegada = DateTime.Now;
            var Frete = "Avião";







            //Act
            var Produto = new Produto(Nome, Origem, Destino, Quantidade, Valor, Importador, Exportador, Embarque, Chegada, Frete);


            //Assert
            Assert.Equal(Produto.nomeProduto, Nome);

            Assert.Equal(Produto.paisDeOrigem, Origem);
            Assert.Equal(Produto.paisDeDestino, Destino);
            Assert.Equal(Produto.dataEmbarque, Embarque);
        }
    }
}