using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.DAL
{
    public class DangKyXemPhongDAL
    {
        #region instance

        private static DangKyXemPhongDAL instance;

        public static DangKyXemPhongDAL Instance
        {
            get
            {
                if (instance == null) instance = new DangKyXemPhongDAL();
                return instance;
            }
            private set { instance = value; }
        }

        private DangKyXemPhongDAL()
        {
        }

        #endregion

        Hosman123Context dbContext = new Hosman123Context();
        public List<DangKyXemPhong> GetAllItems()
        {
            return dbContext.DangKyXemPhongs.ToList();
        }
        public bool PostNewItem(DangKyXemPhong newItem)
        {
            dbContext.DangKyXemPhongs.Add(newItem);
            return dbContext.SaveChanges() > 0;
        }
        public DangKyXemPhong GetItemByID(string maDangKy)
        {
            DangKyXemPhong dangKyXemPhong = dbContext.DangKyXemPhongs.Where(x => x.MaDangKy.Equals(maDangKy)).FirstOrDefault();
            return dangKyXemPhong;
        }
        public bool ItemExistsByID(string maDangKy)
        {
            return dbContext.DangKyXemPhongs.Any(e => e.MaDangKy == maDangKy);
        }
        public bool PutItem(DangKyXemPhong updateItem)
        {
            dbContext.Entry(updateItem).State = EntityState.Modified;
            return dbContext.SaveChanges() > 0;
        }
        public List<DangKyXemPhong> GetItemsByKhuTro(string maKhuTro)
        {
            var list =
                     from KhuTro in dbContext.KhuTros.Where(n => n.MaKhuTro == maKhuTro).AsEnumerable()
                     join p in dbContext.Phongs on KhuTro.MaKhuTro equals p.MaKhuTro
                     join dangKyXemPhong in dbContext.DangKyXemPhongs on p.MaPhong equals dangKyXemPhong.MaPhong
                     select dangKyXemPhong;
            return list.ToList();
        }
        public bool RemoveItem(string maDangKy)
        {
            DangKyXemPhong dangKyXemPhong = dbContext.DangKyXemPhongs.Where(x => x.MaDangKy.Equals(maDangKy)).FirstOrDefault();
            if (dangKyXemPhong != null)
            {
                dbContext.DangKyXemPhongs.Remove(dangKyXemPhong);
                return dbContext.SaveChanges() > 0;
            }
            else
                return false;
        }
    }
}
