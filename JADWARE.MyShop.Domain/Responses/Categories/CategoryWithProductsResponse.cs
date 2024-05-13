using JADWARE.MyShop.Domain.Responses.Products;

namespace JADWARE.MyShop.Domain.Responses.Categories
{
    public class CategoryWithProductsResponse
    {
        public int CategoriaId { get; set; }
        public string Categoria { get; set; }
        public IEnumerable<BasicProduct> Productos {get; set; }
    }
}
