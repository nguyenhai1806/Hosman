namespace hosman_api.Models
{
    public class Login
    {
        private string email;
        private string matKhau;

        public string Email { get => email; set => email = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
    }
}
