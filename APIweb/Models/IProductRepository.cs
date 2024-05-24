using APIweb.Models;
using FluentValidation;

namespace APIweb.Models
{
    public interface IProductRepository
    {
        //Utilizando o padrão Repository para melhorar o design e arquitetura do projeto
        //Classe destinada a criação da interface, com metodos de adicionar, deletar, buscar e editar produtos
        Task Add(Produto produto);
        Task<List<Produto> >Get();
        Task Delete(Guid id);
        Task Update(Guid id, Produto produtoAtualizado);
        Task<Produto> GetById(Guid id);


    }
}
