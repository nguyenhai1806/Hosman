using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.DAL
{
    public class HoaDonNuocDAL
    {
        #region instance
        private static HoaDonNuocDAL instance;
        public static HoaDonNuocDAL Instance
        {
            get
            {
                if (instance == null) instance = new HoaDonNuocDAL();
                return instance;
            }
            private set { instance = value; }
        }
        private HoaDonNuocDAL()
        {

        }
        #endregion
        Hosman123Context dbContext = new Hosman123Context();
        public List<HoaDonNuoc> GetAllItems()
        {
            return dbContext.HoaDonNuocs.ToList();
        }
        public bool PostNewItem(HoaDonNuoc item)
        {
            dbContext.HoaDonNuocs.Add(item);
            return dbContext.SaveChanges() > 0;
        }
        public HoaDonNuoc GetItemByID(string maHoaDon)
        {
            HoaDonNuoc hoaDonNuoc = dbContext.HoaDonNuocs.Where(x => x.MaHoaDon.Equals(maHoaDon)).FirstOrDefault();
            return hoaDonNuoc;
        }
        public bool ItemExistsByID(string maHoaDon)
        {
            return dbContext.HoaDonNuocs.Any(e => e.MaHoaDon == maHoaDon);
        }
        public bool RemoveItem(string maHoaDon)
        {
            HoaDonNuoc hoaDonNuoc = dbContext.HoaDonNuocs.Where(x => x.MaHoaDon.Equals(maHoaDon)).FirstOrDefault();
            if (hoaDonNuoc != null)
            {
                dbContext.HoaDonNuocs.Remove(hoaDonNuoc);
                return dbContext.SaveChanges() > 0;
            }
            else
                return false;
        }
        public bool PutItem(HoaDonNuoc updateItem)
        {
            dbContext.Entry(updateItem).State = EntityState.Modified;
            return true;
        }
    }
}
