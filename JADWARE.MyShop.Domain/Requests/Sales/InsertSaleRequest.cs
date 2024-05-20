namespace JADWARE.MyShop.Domain.Requests.Sales
{
    public class InsertSaleRequest
    {
        public int ClienteId { get; set; }
        public string NumCtaPago { get; set; }
        public int Total { get; set; }
        public string PaisEntrega { get; set; }
        public string EstadoEntrega { get; set; }
        public string CiudadEntrega { get; set; }
        public string CpEntrega { get; set; }
        public string DomicilioEntrega { get; set; }
        public SaleItemRequest[] SaleItems { get; set; }

    }
}
