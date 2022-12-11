using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.DAL
{
    public class DichVuDAL
    {
        #region instance
        private static DichVuDAL instance;
        public static DichVuDAL Instance
        {
            get
            {
                if (instance == null) instance = new DichVuDAL();
                return instance;
            }
            private set { instance = value; }
        }
        private DichVuDAL()
        {

        }
        #endregion
        Hosman123Context dbContext = new Hosman123Context();
        public List<DichVu> GetAllItems()
        {
            return dbContext.DichVus.ToList();
        }
        public bool PostNewItem(DichVu item)
        {
            dbContext.DichVus.Add(item);
            return dbContext.SaveChanges() > 0;
        }
        public DichVu GetItemByID(string maDichVu)
        {
            DichVu dichVu = dbContext.DichVus.Where(x => x.MaDichVu.Equals(maDichVu)).FirstOrDefault();
            return dichVu;
        }
        public bool ItemExistsByID(string maDichVu)
        {
            return dbContext.DichVus.Any(e => e.MaDichVu == maDichVu);
        }
        public bool RemoveItem(string maDichVu)
        {
            DichVu dichVu = dbContext.DichVus.Where(x => x.MaDichVu.Equals(maDichVu)).FirstOrDefault();
            if (dichVu != null)
            {
                dbContext.DichVus.Remove(dichVu);
                return dbContext.SaveChanges() > 0;
            }
            else
                return false;
        }
        public bool PutItem(DichVu updateItem)
        {
            dbContext.Entry(updateItem).State = EntityState.Modified;
            return true;
        }
    }
}
