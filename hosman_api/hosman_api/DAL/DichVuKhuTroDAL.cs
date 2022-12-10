using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.DAL
{
    public class DichVuKhuTroDAL
    {
        #region instance
        private static DichVuKhuTroDAL instance;
        public static DichVuKhuTroDAL Instance
        {
            get
            {
                if (instance == null) instance = new DichVuKhuTroDAL();
                return instance;
            }
            private set { instance = value; }
        }
        private DichVuKhuTroDAL()
        {

        }
        #endregion
        Hosman123Context dbContext = new Hosman123Context();
        public List<DichVuKhuTro> GetAllItems()
        {
            return dbContext.DichVuKhuTros.ToList();
        }
        public bool PostNewItem(DichVuKhuTro item)
        {
            dbContext.DichVuKhuTros.Add(item);
            return dbContext.SaveChanges() > 0;
        }
        public DichVuKhuTro GetItemByID(string maDichVu)
        {
            DichVuKhuTro dichVuKhuTro = dbContext.DichVuKhuTros.Where(x => x.MaDichVu.Equals(maDichVu)).FirstOrDefault();
            return dichVuKhuTro;
        }
        public bool ItemExistsByID(string maDichVu)
        {
            return dbContext.DichVuKhuTros.Any(e => e.MaDichVu == maDichVu);
        }
        public bool RemoveItem(string maDichVu)
        {
            DichVuKhuTro dichVuKhuTro = dbContext.DichVuKhuTros.Where(x => x.MaDichVu.Equals(maDichVu)).FirstOrDefault();
            if (dichVuKhuTro != null)
            {
                dbContext.DichVuKhuTros.Remove(dichVuKhuTro);
                return dbContext.SaveChanges() > 0;
            }
            else
                return false;
        }
        public bool PutItem(DichVuKhuTro updateItem)
        {
            dbContext.Entry(updateItem).State = EntityState.Modified;
            return true;
        }
    }
}
