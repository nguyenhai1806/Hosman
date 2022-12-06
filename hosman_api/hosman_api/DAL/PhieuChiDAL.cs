using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.DAL
{
    public class PhieuChiDAL
    {
        #region instance

        private static PhieuChiDAL instance;

        public static PhieuChiDAL Instance
        {
            get
            {
                if (instance == null) instance = new PhieuChiDAL();
                return instance;
            }
            private set { instance = value; }
        }

        private PhieuChiDAL()
        {
        }

        #endregion instance

        private Hosman123Context dbContext = new Hosman123Context();

        public List<PhieuChi> GetAllItems()
        {
            return dbContext.PhieuChis.ToList();
        }

        public bool PostNewItem(PhieuChi newItem)
        {
            dbContext.PhieuChis.Add(newItem);
            return dbContext.SaveChanges() > 0;
        }

        public PhieuChi GetItemByID(string maPhieuChi)
        {
            return dbContext.PhieuChis.Find(maPhieuChi);
        }

        public bool RemoveItem(string maPhieuChi)
        {
            PhieuChi temp = GetItemByID(maPhieuChi);
            if (temp != null)
            {
                dbContext.PhieuChis.Remove(temp);
                return dbContext.SaveChanges() > 0;
            }

            return false;
        }

        public bool PutItem(PhieuChi updateItem)
        {
            dbContext.Entry(updateItem).State = EntityState.Modified;
            return dbContext.SaveChanges() > 0;
        }
    }
}