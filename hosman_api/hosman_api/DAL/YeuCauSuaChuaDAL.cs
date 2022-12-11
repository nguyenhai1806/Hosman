using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.DAL
{
    public class YeuCauSuaChuaDAL
    {
        #region instance

        private static YeuCauSuaChuaDAL instance;

        public static YeuCauSuaChuaDAL Instance
        {
            get
            {
                if (instance == null) instance = new YeuCauSuaChuaDAL();
                return instance;
            }
            private set { instance = value; }
        }

        private YeuCauSuaChuaDAL()
        {
        }

        #endregion

        Hosman123Context dbContext = new Hosman123Context();
        public List<YeuCauSauChua> GetAllItems()
        {
            return dbContext.YeuCauSauChuas.ToList();
        }
        public bool PostNewItem(YeuCauSauChua newItem)
        {
            dbContext.YeuCauSauChuas.Add(newItem);
            return dbContext.SaveChanges() > 0;
        }
        public YeuCauSauChua GetItemByID(string maYeuCau)
        {
            YeuCauSauChua yeuCauSauChua = dbContext.YeuCauSauChuas.Where(x => x.MaYeuCau.Equals(maYeuCau)).FirstOrDefault();
            return yeuCauSauChua;
        }
        public bool ItemExistsByID(string maYeuCau)
        {
            return dbContext.YeuCauSauChuas.Any(e => e.MaYeuCau == maYeuCau);
        }
        public bool PutItem(YeuCauSauChua updateItem)
        {
            dbContext.Entry(updateItem).State = EntityState.Modified;
            return dbContext.SaveChanges() > 0;
        }

        public bool RemoveItem(string maYeuCau)
        {
            YeuCauSauChua yeuCauSauChua = dbContext.YeuCauSauChuas.Where(x => x.MaYeuCau.Equals(maYeuCau)).FirstOrDefault();
            if (yeuCauSauChua != null)
            {
                dbContext.YeuCauSauChuas.Remove(yeuCauSauChua);
                return dbContext.SaveChanges() > 0;
            }
            else
                return false;
        }
    }
}
