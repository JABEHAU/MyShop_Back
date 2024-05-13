namespace JADWARE.MyShop.Domain.Models
{
    public class User
    {
        public int UsuarioId {  get; set; }
        public string Correo { get; set; }
        public string Nombre {  get; set; }
        public string Telefono { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
        public string Domicilio { get; set; }
        public string Cp { get; set; }
        public int EsVendedor { get; set; }
        public string? NumCtaBeneficiario { get; set; }
        public string? NombreCtaBeneficiario { get; set; }
    }
}
