using System.Collections.Generic;

namespace WebApiProdutos.DTOs
{
    public class CategoriaDTO
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public string ImageURL { get; set; }
        public ICollection<ProdutoDTO> Produtos { get; set; }
    }
}
