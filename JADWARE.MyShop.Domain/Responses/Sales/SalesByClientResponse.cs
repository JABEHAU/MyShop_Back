namespace JADWARE.MyShop.Domain.Responses.Sales
{
    public class SalesByClientResponse
    {
        public int VentaId { get; set; }
        public string Status {  get; set; }
        public DateTime Fecha { get; set; }
        public float Total { get; set; }
        public string PaisEntrega { get;set; }
        public string EstadoEntrega { get; set; }
        public string CiudadEntrega { get; set; }
        public string CpEntrega { get; set; }
        public string DomicilioEntrega { get; set; }
    }
}
