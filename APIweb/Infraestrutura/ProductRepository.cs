using APIweb.Data;
using APIweb.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace APIweb.Infraestrutura
{
    public class ProductRepository : IProductRepository

    {
        //implementação da interface

        private readonly AppDbContext _context = new AppDbContext();
        

        public async Task Add(Produto produto)
        {
            
            await _context.Products.AddAsync(produto);
            await _context.SaveChangesAsync();
            
        }
        public async Task<Produto> GetById(Guid id)
        {
            return await _context.Products.FindAsync(id);
            
        }

        public async Task Delete ( Guid id)
        {
            var produto = await _context.Products.FirstOrDefaultAsync(p => p.id == id);
            if (produto != null)
            {
                _context.Products.Remove(produto);
                await _context.SaveChangesAsync();
            }
           
        }

        public async Task<List<Produto>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task Update(Guid id, Produto produtoAtualizado) 
        {
            var produto = await _context.Products.FirstOrDefaultAsync(p => p.id == id);
            if (produto != null)
            {
                produto.AtualizarTodos(produtoAtualizado);
                await _context.SaveChangesAsync();

            }
        }

        
    }
}
