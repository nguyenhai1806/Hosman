using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.DAL
{
    public class LoaiPhongDAL
    {
        #region instance

        private static LoaiPhongDAL instance;

        public static LoaiPhongDAL Instance
        {
            get
            {
                if (instance == null) instance = new LoaiPhongDAL();
                return instance;
            }
            private set { instance = value; }
        }

        private LoaiPhongDAL()
        {
        }

        #endregion instance

        private Hosman123Context dbContext = new Hosman123Context();

        public List<LoaiPhong> GetAllItems()
        {
            return dbContext.LoaiPhongs.ToList();
        }

        public bool PostNewItem(LoaiPhong newItem)
        {
            dbContext.LoaiPhongs.Add(newItem);
            return dbContext.SaveChanges() > 0;
        }

        public LoaiPhong GetItemByID(string maLoaiPhong)
        {
            return dbContext.LoaiPhongs.Find(maLoaiPhong);
        }

        public bool RemoveItem(string maLoaiPhong)
        {
            LoaiPhong loaiPhong = GetItemByID(maLoaiPhong);
            if (loaiPhong != null)
            {
                dbContext.LoaiPhongs.Remove(loaiPhong);
                return dbContext.SaveChanges() > 0;
            }
            return false;
        }

        public bool PutItem(LoaiPhong updateItem)
        {
            dbContext.Entry(updateItem).State = EntityState.Modified;
            return true;
        }
    }
}