using hosman_api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.DAL
{
    public class DanhSachNguoiTroDAL
    {
        #region instance

        private static DanhSachNguoiTroDAL instance;

        public static DanhSachNguoiTroDAL Instance
        {
            get
            {
                if (instance == null) instance = new DanhSachNguoiTroDAL();
                return instance;
            }
            private set { instance = value; }
        }

        private DanhSachNguoiTroDAL()
        {
        }

        #endregion instance

        private Hosman123Context dbContext = new Hosman123Context();

        public List<DanhSachNguoiTro> GetAllItems()
        {
            return dbContext.DanhSachNguoiTros.ToList();
        }

        public bool PostNewItem(DanhSachNguoiTro newItem)
        {
            dbContext.DanhSachNguoiTros.Add(newItem);
            return dbContext.SaveChanges() > 0;
        }

        public DanhSachNguoiTro GetItemByID(string maNguoiTro)
        {
            return dbContext.DanhSachNguoiTros.SingleOrDefault(x => x.MaNguoiTro.Equals(maNguoiTro));
        }

        public bool RemoveItem(string maNguoiTro)
        {
            DanhSachNguoiTro nguoiTro = dbContext.DanhSachNguoiTros.SingleOrDefault(x => x.MaNguoiTro == maNguoiTro);
            if (nguoiTro != null)
            {
                dbContext.DanhSachNguoiTros.Remove(nguoiTro);
                return dbContext.SaveChanges() > 0;
            }
            else
                return false;
        }

        public bool ItemExistsByID(string maNguoiTro)
        {
            return dbContext.QlNhomNguoiDungs.Any(e => e.MaNhom == maNguoiTro);
        }

        public bool ItemExistsByName(string tenNhom)
        {
            return dbContext.QlNhomNguoiDungs.Any(e => e.TenNhom == tenNhom);
        }

        public List<DanhSachNguoiTro> GetItemsByChuTro(string maChuTro)
        {
            List<DanhSachNguoiTro> danhSach = dbContext.DanhSachNguoiTros
                .FromSqlRaw(@"SELECT ds.* FROM dbo.DanhSachNguoiTro ds
                            JOIN dbo.HopDongThue  h ON h.MaHopDong = ds.MaHopDong
                            JOIN dbo.Phong p ON p.MaPhong = h.MaPhong
                            JOIN dbo.KhuTro k ON k.MaKhuTro = p.MaKhuTro
                            JOIN dbo.NguoiDung n ON n.MaNguoiDung = k.MaNguoiDung
                            WHERE k.MaNguoiDung = @MaNguoiDung", new SqlParameter("@MaNguoiDung", maChuTro)).ToList();
            return danhSach;
        }

        public List<DanhSachNguoiTro> GetItemsByHopDong(string maHopDong)
        {
            List<DanhSachNguoiTro> list = dbContext.DanhSachNguoiTros.ToList();
            return list.FindAll(x => x.MaHopDong.Equals(maHopDong));
        }
    }
}