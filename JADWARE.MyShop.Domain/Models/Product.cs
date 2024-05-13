using JADWARE.MyShop.Domain.Responses.Products;

namespace JADWARE.MyShop.Domain.Models
{
    public class Product
    {
		public int ProductoId {  get; set; }
		public int VendedorId {  get; set; }
		public int CategoriaId {  get; set; }
		public string Nombre { get; set;}
		public string Descripcion { get; set; }
		public string Marca {  get; set; }
        public string Modelo { get; set; }
        public string Genero { get; set; }
        public int Cantidad { get; set; }
		public float Precio { get; set; }
		public int EsOferta { get; set; }
		public float? PrecioOferta { get; set; }
		public IEnumerable<Photo> Fotos { get; set; }
		public IEnumerable<Comment> Comentarios { get; set; }
    }
}
