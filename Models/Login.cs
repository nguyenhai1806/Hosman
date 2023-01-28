namespace hosman_api.Models
{
    public class Login
    {
        private string taiKhoan;
        private string matKhau;

        public string TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
    }
}
