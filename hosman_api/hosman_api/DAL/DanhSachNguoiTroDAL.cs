using hosman_api.Models;
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

        public bool PutItem(DanhSachNguoiTro updateItem)
        {
            dbContext.Entry(updateItem).State = EntityState.Modified;
            return dbContext.SaveChanges() > 0;
        }

        public bool ItemExistsByID(string maNguoiTro)
        {
            return dbContext.QlNhomNguoiDungs.Any(e => e.MaNhom == maNguoiTro);
        }

        public List<DanhSachNguoiTro> GetItemsByChuTro(string maChuTro)
        {
            //List<DanhSachNguoiTro> danhSach = dbContext.DanhSachNguoiTros
            //    .FromSqlRaw(@"SELECT ds.* FROM dbo.DanhSachNguoiTro ds
            //                JOIN dbo.HopDongThue  h ON h.MaHopDong = ds.MaHopDong
            //                JOIN dbo.Phong p ON p.MaPhong = h.MaPhong
            //                JOIN dbo.KhuTro k ON k.MaKhuTro = p.MaKhuTro
            //                JOIN dbo.NguoiDung n ON n.MaNguoiDung = k.MaNguoiDung
            //                WHERE k.MaNguoiDung = @MaNguoiDung", new SqlParameter("@MaNguoiDung", maChuTro)).ToList();
            var list =
                from nguoiDung in dbContext.NguoiDungs.Where(n => n.MaNguoiDung == maChuTro).AsEnumerable()
                join k in dbContext.KhuTros on nguoiDung.MaNguoiDung equals k.MaNguoiDung
                join p in dbContext.Phongs on k.MaKhuTro equals p.MaKhuTro
                join h in dbContext.HopDongThues on p.MaPhong equals h.MaPhong
                join nguoiTro in dbContext.DanhSachNguoiTros on h.MaHopDong equals nguoiTro.MaHopDong
                select nguoiTro;
            return list.ToList();
        }

        public List<DanhSachNguoiTro> GetItemsByHopDong(string maHopDong)
        {
            List<DanhSachNguoiTro> list = dbContext.DanhSachNguoiTros.Where(x => x.MaHopDong == maHopDong).ToList();
            return list;
        }
    }
}