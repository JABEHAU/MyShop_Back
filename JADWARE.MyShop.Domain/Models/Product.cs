namespace JADWARE.MyShop.Domain.Models
{
    public class Product
    {
		public int productoId {  get; set; }
		public int vendedorId {  get; set; }
		public int categoriaId {  get; set; }
		public string nombre { get; set;}
		public string descripcion { get; set; }
		public int cantidad { get; set; }
		public float precio { get; set; }
    }
}
