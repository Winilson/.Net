using System.Threading.Tasks;
using WebApiProdutos.Context;

namespace WebApiProdutos.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(AppDbContext contexto)
        {
            _context = contexto;
        }

        private ProdutoRepository _produtorepo;
        private CategoriaRepository _categoriarepo;
        public AppDbContext _context;


        public IProdutoRepository ProdutoRepository
        {
            get
            {
                return _produtorepo = _produtorepo ?? new ProdutoRepository(_context);
            }
        }

        public ICategoriaRepository CategoriaRepository
        {
            get
            {
                return _categoriarepo = _categoriarepo ?? new CategoriaRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Disponse()
        {
            _context.Dispose();
        }
    }
}
