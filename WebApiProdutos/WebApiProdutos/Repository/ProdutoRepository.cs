using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProdutos.Context;
using WebApiProdutos.Models;
using WebApiProdutos.Pagination;

namespace WebApiProdutos.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext contexto) : base(contexto)
        {
        }

        public PagedList<Produto> GetProdutos(ProdutosParameters produtosParameters)
        {
            return PagedList<Produto>.ToPagedList(Get().OrderBy(on => on.ProdutoId), 
                produtosParameters.PageNumber, produtosParameters.PageSize);


            //return Get()
                //.OrderBy(on => on.Nome)
                //.Skip((produtosParameters.PageNumber - 1) * produtosParameters.PageSize)
                //.Take(produtosParameters.PageSize)
                //.ToList();
        }

        public async Task<IEnumerable<Produto>> GetProdutosPorPreco()
        {
            return await Get().OrderBy(c => c.Preco).ToListAsync();
        }
    }
}
