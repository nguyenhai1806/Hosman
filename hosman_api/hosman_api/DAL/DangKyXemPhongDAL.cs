using hosman_api.Models;

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
            return dbContext.QlNhomNguoiDungs.Any(e => e.MaNhom == maDangKy);
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
