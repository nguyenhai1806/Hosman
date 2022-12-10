using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.DAL
{
    public class HoaDonDAL
    {
        #region instance
        private static HoaDonDAL instance;
        public static HoaDonDAL Instance
        {
            get
            {
                if (instance == null) instance = new HoaDonDAL();
                return instance;
            }
            private set { instance = value; }
        }
        private HoaDonDAL()
        {

        }
        #endregion
        Hosman123Context dbContext = new Hosman123Context();
        public List<HoaDon> GetAllItems()
        {
            return dbContext.HoaDons.ToList();
        }
        public bool PostNewItem(HoaDon item)
        {
            dbContext.HoaDons.Add(item);
            return dbContext.SaveChanges() > 0;
        }
        public HoaDon GetItemByID(string maHoaDon)
        {
            HoaDon hoaDon = dbContext.HoaDons.Where(x => x.MaHoaDon.Equals(maHoaDon)).FirstOrDefault();
            return hoaDon;
        }
        public bool ItemExistsByID(string maHoaDon)
        {
            return dbContext.HoaDons.Any(e => e.MaHoaDon == maHoaDon);
        }
        public bool RemoveItem(string maHoaDon)
        {
            HoaDon hoaDon = dbContext.HoaDons.Where(x => x.MaHoaDon.Equals(maHoaDon)).FirstOrDefault();
            if (hoaDon != null)
            {
                dbContext.HoaDons.Remove(hoaDon);
                return dbContext.SaveChanges() > 0;
            }
            else
                return false;
        }
        public bool PutItem(HoaDon updateItem)
        {
            dbContext.Entry(updateItem).State = EntityState.Modified;
            return true;
        }
    }
}
