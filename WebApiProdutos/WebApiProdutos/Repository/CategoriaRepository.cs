using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProdutos.Context;
using WebApiProdutos.Models;
using WebApiProdutos.Pagination;

namespace WebApiProdutos.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext contexto):base(contexto)
        {
        }

        public async Task<IEnumerable<Categoria>> GetCategoriaProdutos()
        {
            return await Get().Include(x => x.Produtos).ToListAsync();
        }

        public PagedList<Categoria> GetCategoriasPaginas(CategoriaParameters categoriaParameters)
        {
            return PagedList<Categoria>.ToPagedList(Get().OrderBy(on => on.Nome),
                                  categoriaParameters.PageNumber,
                                  categoriaParameters.PageSize);
        }
    }
}
