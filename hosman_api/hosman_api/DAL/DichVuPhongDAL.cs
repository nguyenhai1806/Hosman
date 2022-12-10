using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.DAL
{
    public class DichVuPhongDAL
    {
        #region instance
        private static DichVuPhongDAL instance;
        public static DichVuPhongDAL Instance
        {
            get
            {
                if (instance == null) instance = new DichVuPhongDAL();
                return instance;
            }
            private set { instance = value; }
        }
        private DichVuPhongDAL()
        {

        }
        #endregion
        Hosman123Context dbContext = new Hosman123Context();
        public List<DichVuPhong> GetAllItems()
        {
            return dbContext.DichVuPhongs.ToList();
        }
        public bool PostNewItem(DichVuPhong item)
        {
            dbContext.DichVuPhongs.Add(item);
            return dbContext.SaveChanges() > 0;
        }
        public DichVuPhong GetItemByID(string maDichVu)
        {
            DichVuPhong dichVuPhong = dbContext.DichVuPhongs.Where(x => x.MaDichVu.Equals(maDichVu)).FirstOrDefault();
            return dichVuPhong;
        }
        public bool ItemExistsByID(string maDichVu)
        {
            return dbContext.DichVuPhongs.Any(e => e.MaDichVu == maDichVu);
        }
        public bool RemoveItem(string maDichVu)
        {
            DichVuPhong dichVuPhong = dbContext.DichVuPhongs.Where(x => x.MaDichVu.Equals(maDichVu)).FirstOrDefault();
            if (dichVuPhong != null)
            {
                dbContext.DichVuPhongs.Remove(dichVuPhong);
                return dbContext.SaveChanges() > 0;
            }
            else
                return false;
        }
        public bool PutItem(DichVuPhong updateItem)
        {
            dbContext.Entry(updateItem).State = EntityState.Modified;
            return true;
        }
    }
}
