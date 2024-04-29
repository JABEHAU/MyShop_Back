namespace JADWARE.MyShop.Domain.Requests.Users
{
    public class GetUserByMailAndPassRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
