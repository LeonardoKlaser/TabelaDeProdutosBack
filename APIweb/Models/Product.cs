using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIweb.Models
{
    [Table("produto")]
    public class Produto
    {
        [Key]
        public Guid id { get; init; }
        public bool ativo { get; private set; }
        public string nomeProduto { get; private set; }
        public string paisDeOrigem { get; private set; }
        public string paisDeDestino { get; private set; }
        public int quantidade { get; private set; }
        public int valorUnitario { get; private set; }
        public string importador { get; private set; }
        public string exportador { get; private set; }
        public DateTime dataEmbarque { get; private set; }
        public DateTime dataChegada { get; private set; }
        public string freteModo { get; private set; }
        public Produto(string nomeProduto, string paisDeOrigem, string paisDeDestino, int quantidade, int valorUnitario, string importador, string exportador, DateTime dataEmbarque, DateTime dataChegada, string freteModo)
        {
            this.id = Guid.NewGuid();
            this.ativo = true;
            this.nomeProduto = nomeProduto;
            this.paisDeOrigem = paisDeOrigem;
            this.paisDeDestino = paisDeDestino;
            this.quantidade = quantidade;
            this.valorUnitario = valorUnitario;
            this.importador = importador;
            this.exportador = exportador;
            this.dataEmbarque = dataEmbarque;
            this.dataChegada = dataChegada;
            this.freteModo = freteModo;
        }

       

        public void AtualizarTodos(Produto novoProduto)
        {
            // Atualize todas as propriedades com os valores do novo produto
            this.nomeProduto = novoProduto.nomeProduto;
            this.paisDeOrigem = novoProduto.paisDeOrigem;
            this.paisDeDestino = novoProduto.paisDeDestino;
            this.quantidade = novoProduto.quantidade;
            this.valorUnitario = novoProduto.valorUnitario;
            this.importador = novoProduto.importador;
            this.exportador = novoProduto.exportador;
            this.dataEmbarque = novoProduto.dataEmbarque;
            this.dataChegada = novoProduto.dataChegada;
            this.freteModo = novoProduto.freteModo;
        }


    }
}