using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JADWARE.MyShop.Domain.Responses.Products
{
    public class BasicProduct
    {
        public int ProductoId { get; set; }
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public int EsOferta { get; set; }
        public float? PrecioOferta { get; set; }
        public string FotoPrincipal { get; set; }
    }
}
