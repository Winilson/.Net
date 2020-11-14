using System.Threading.Tasks;

namespace WebApiProdutos.Repository
{
    public interface IUnitOfWork
    { 
        IProdutoRepository ProdutoRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }
        Task Commit();
    }
}
