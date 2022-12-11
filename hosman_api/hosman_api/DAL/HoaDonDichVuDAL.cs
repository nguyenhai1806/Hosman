using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.DAL
{
    public class HoaDonDichVuDAL
    {
        #region instance
        private static HoaDonDichVuDAL instance;
        public static HoaDonDichVuDAL Instance
        {
            get
            {
                if (instance == null) instance = new HoaDonDichVuDAL();
                return instance;
            }
            private set { instance = value; }
        }
        private HoaDonDichVuDAL()
        {

        }
        #endregion
        Hosman123Context dbContext = new Hosman123Context();
        public List<HoaDonDichVu> GetAllItems()
        {
            return dbContext.HoaDonDichVus.ToList();
        }
        public bool PostNewItem(HoaDonDichVu item)
        {
            dbContext.HoaDonDichVus.Add(item);
            return dbContext.SaveChanges() > 0;
        }
        public HoaDonDichVu GetItemByID(string maHoaDon)
        {
            HoaDonDichVu hoaDonDichVu = dbContext.HoaDonDichVus.Where(x => x.MaHoaDon.Equals(maHoaDon)).FirstOrDefault();
            return hoaDonDichVu;
        }
        public bool ItemExistsByID(string maHoaDon)
        {
            return dbContext.HoaDonDichVus.Any(e => e.MaHoaDon == maHoaDon);
        }
        public bool RemoveItem(string maHoaDon)
        {
            HoaDonDichVu hoaDonDichVu = dbContext.HoaDonDichVus.Where(x => x.MaHoaDon.Equals(maHoaDon)).FirstOrDefault();
            if (hoaDonDichVu != null)
            {
                dbContext.HoaDonDichVus.Remove(hoaDonDichVu);
                return dbContext.SaveChanges() > 0;
            }
            else
                return false;
        }
        public bool PutItem(HoaDonDichVu updateItem)
        {
            dbContext.Entry(updateItem).State = EntityState.Modified;
            return true;
        }
    }
}
