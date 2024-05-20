namespace JADWARE.MyShop.Domain.Requests.Sales
{
    public class SaleItemRequest
    {
        public int VentaId {  get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public float PrecioUnitario { get; set; }
        public float TotalItem { get; set; }
    }
}
