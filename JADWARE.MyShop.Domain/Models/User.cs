namespace JADWARE.MyShop.Domain.Models
{
    public class User
    {
        public int usuarioId {  get; set; }
        public string correo { get; set; }
        public string nombre {  get; set; }
        public string telefono { get; set; }
        public string pais { get; set; }
        public string estado { get; set; }
        public string ciudad { get; set; }
        public string domicilio { get; set; }
        public string cp { get; set; }
        public int esVendedor { get; set; }
        public string? numCtaBeneficiario { get; set; }
        public string? nombreCtaBeneficiario { get; set; }
    }
}
