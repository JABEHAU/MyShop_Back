namespace JADWARE.MyShop.Domain.Requests.Users
{
    public class InsertUserRequest
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber {  get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Password {  get; set; }
    }
}
