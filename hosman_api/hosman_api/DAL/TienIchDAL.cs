using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.DAL
{
    public class TienIchDAL
    {
        #region instance

        private static TienIchDAL instance;

        public static TienIchDAL Instance
        {
            get
            {
                if (instance == null) instance = new TienIchDAL();
                return instance;
            }
            private set { instance = value; }
        }

        private TienIchDAL()
        {
        }

        #endregion instance

        private Hosman123Context dbContext = new Hosman123Context();

        public List<TienIch> GetAllItems()
        {
            return dbContext.TienIches.ToList();
        }

        public bool PostNewItem(TienIch newItem)
        {
            dbContext.TienIches.Add(newItem);
            return dbContext.SaveChanges() > 0;
        }

        public TienIch GetItemByID(string maTienIch)
        {
            return dbContext.TienIches.Find(maTienIch);
        }

        public bool RemoveItem(string maTienIch)
        {
            TienIch removeItem = GetItemByID(maTienIch);
            if (removeItem != null)
            {
                dbContext.TienIches.Remove(removeItem);
                return dbContext.SaveChanges() > 0;
            }

            return false;
        }

        public bool PutItem(TienIch updateItem)
        {
            dbContext.Entry(updateItem).State = EntityState.Modified;
            return true;
        }

        public bool ItemExistsByID(string maTienIch)
        {
            return dbContext.TienIches.Find(maTienIch) != null;
        }
    }
}