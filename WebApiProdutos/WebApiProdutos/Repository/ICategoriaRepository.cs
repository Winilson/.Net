using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiProdutos.Models;
using WebApiProdutos.Pagination;

namespace WebApiProdutos.Repository
{
    public interface ICategoriaRepository:IRepository<Categoria>
    {
        PagedList<Categoria>
            GetCategoriasPaginas(CategoriaParameters categoriaParameters);
        Task<IEnumerable<Categoria>> GetCategoriaProdutos();
    }
}
