using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.DAL
{
    public class DongHoNuocDAL
    {
        #region instance
        private static DongHoNuocDAL instance;
        public static DongHoNuocDAL Instance
        {
            get
            {
                if (instance == null) instance = new DongHoNuocDAL();
                return instance;
            }
            private set { instance = value; }
        }
        private DongHoNuocDAL()
        {

        }
        #endregion
        Hosman123Context dbContext = new Hosman123Context();
        public List<DongHoNuoc> GetAllItems()
        {
            return dbContext.DongHoNuocs.ToList();
        }
        public bool PostNewItem(DongHoNuoc item)
        {
            dbContext.DongHoNuocs.Add(item);
            return dbContext.SaveChanges() > 0;
        }
        public DongHoNuoc GetItemByID(string maBanGhi)
        {
            DongHoNuoc dongHoNuoc = dbContext.DongHoNuocs.Where(x => x.MaBanGhi.Equals(maBanGhi)).FirstOrDefault();
            return dongHoNuoc;
        }
        public bool ItemExistsByID(string maBanGhi)
        {
            return dbContext.DongHoDiens.Any(e => e.MaBanGhi == maBanGhi);
        }
        public bool RemoveItem(string maBanGhi)
        {
            DongHoNuoc dongHoNuoc = dbContext.DongHoNuocs.Where(x => x.MaBanGhi.Equals(maBanGhi)).FirstOrDefault();
            if (dongHoNuoc != null)
            {
                dbContext.DongHoNuocs.Remove(dongHoNuoc);
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
