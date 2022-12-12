using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.DAL
{
    public class DmManHinhDAL
    {
        #region instance
        private static DmManHinhDAL instance;
        public static DmManHinhDAL Instance
        {
            get
            {
                if (instance == null) instance = new DmManHinhDAL();
                return instance;
            }
            private set { instance = value; }
        }
        private DmManHinhDAL()
        {

        }
        #endregion
        Hosman123Context dbContext = new Hosman123Context();
        public List<DmManHinh> GetAllItems()
        {
            return dbContext.DmManHinhs.ToList();
        }
        public bool PostNewItem(DmManHinh item)
        {
            dbContext.DmManHinhs.Add(item);
            return dbContext.SaveChanges() > 0;
        }
        public DmManHinh GetItemByID(string maManHinh)
        {
            DmManHinh dmManHinh = dbContext.DmManHinhs.Where(x => x.MaManHinh.Equals(maManHinh)).FirstOrDefault();
            return dmManHinh;
        }
        public bool ItemExistsByID(string maManHinh)
        {
            return dbContext.DmManHinhs.Any(e => e.MaManHinh == maManHinh);
        }
        public bool RemoveItem(string maManHinh)
        {
            DmManHinh dmManHinh = dbContext.DmManHinhs.Where(x => x.MaManHinh.Equals(maManHinh)).FirstOrDefault();
            if (dmManHinh != null)
            {
                dbContext.DmManHinhs.Remove(dmManHinh);
                return dbContext.SaveChanges() > 0;
            }
            else
                return false;
        }
        public bool PutItem(DmManHinh updateItem)
        {
            dbContext.Entry(updateItem).State = EntityState.Modified;
            return true;
        }
    }
}
