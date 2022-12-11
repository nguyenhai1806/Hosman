using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.DAL
{
    public class DongHoDienDAL
    {
        #region instance
        private static DongHoDienDAL instance;
        public static DongHoDienDAL Instance
        {
            get
            {
                if (instance == null) instance = new DongHoDienDAL();
                return instance;
            }
            private set { instance = value; }
        }
        private DongHoDienDAL()
        {

        }
        #endregion
        Hosman123Context dbContext = new Hosman123Context();
        public List<DongHoDien> GetAllItems()
        {
            return dbContext.DongHoDiens.ToList();
        }
        public bool PostNewItem(DongHoDien item)
        {
            dbContext.DongHoDiens.Add(item);
            return dbContext.SaveChanges() > 0;
        }
        public DongHoDien GetItemByID(string maBanGhi)
        {
            DongHoDien dongHoDien = dbContext.DongHoDiens.Where(x => x.MaBanGhi.Equals(maBanGhi)).FirstOrDefault();
            return dongHoDien;
        }
        public bool ItemExistsByID(string maBanGhi)
        {
            return dbContext.DongHoDiens.Any(e => e.MaBanGhi == maBanGhi);
        }
        public bool RemoveItem(string maBanGhi)
        {
            DongHoDien dongHoDien = dbContext.DongHoDiens.Where(x => x.MaBanGhi.Equals(maBanGhi)).FirstOrDefault();
            if (dongHoDien != null)
            {
                dbContext.DongHoDiens.Remove(dongHoDien);
                return dbContext.SaveChanges() > 0;
            }
            else
                return false;
        }
        public bool PutItem(DongHoNuoc updateItem)
        {
            dbContext.Entry(updateItem).State = EntityState.Modified;
            return true;
        }
    }
}
