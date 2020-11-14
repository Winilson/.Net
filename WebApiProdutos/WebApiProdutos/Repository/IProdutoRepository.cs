using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiProdutos.Models;
using WebApiProdutos.Pagination;

namespace WebApiProdutos.Repository
{
    public interface IProdutoRepository: IRepository<Produto>
    {
        PagedList<Produto> GetProdutos(ProdutosParameters produtosParameters);
        Task<IEnumerable<Produto>> GetProdutosPorPreco();
    }
}
