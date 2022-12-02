using hosman_api.Models;

namespace hosman_api.DAL
{
    public class BinhLuanDAL
    {
        #region instance
        private static BinhLuanDAL instance;
        public static BinhLuanDAL Instance
        {
            get
            {
                if (instance == null) instance = new BinhLuanDAL();
                return instance;
            }
            private set { instance = value; }
        }
        private BinhLuanDAL()
        {
            
        }
        #endregion
        Hosman123Context dbContext = new Hosman123Context();
        public List<BinhLuan> GetAllItems()
        {
            return dbContext.BinhLuans.ToList();
        }
        public bool PostNewItem(BinhLuan item)
        {
            dbContext.BinhLuans.Add(item);
            return dbContext.SaveChanges() > 0;
        }
        public BinhLuan GetItemByID(string maBinhLuan)
        {
            BinhLuan binhLuan = dbContext.BinhLuans.Where(x => x.MaBinhLuan.Equals(maBinhLuan)).FirstOrDefault();
            return binhLuan;
        }
        public bool ItemExistsByID(string maBinhLuan)
        {
            return dbContext.BinhLuans.Any(e => e.MaBinhLuan == maBinhLuan);
        }
        public bool RemoveItem(string maBinhLuan)
        {
            BinhLuan binhLuan = dbContext.BinhLuans.Where(x => x.MaBinhLuan.Equals(maBinhLuan)).FirstOrDefault();
            if (binhLuan != null)
            {
                dbContext.BinhLuans.Remove(binhLuan);
                return dbContext.SaveChanges() > 0;
            }
            else
                return false;
        }
    }
}
