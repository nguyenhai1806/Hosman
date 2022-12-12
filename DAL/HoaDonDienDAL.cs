using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.DAL
{
    public class HoaDonDienDAL
    {
        #region instance
        private static HoaDonDienDAL instance;
        public static HoaDonDienDAL Instance
        {
            get
            {
                if (instance == null) instance = new HoaDonDienDAL();
                return instance;
            }
            private set { instance = value; }
        }
        private HoaDonDienDAL()
        {

        }
        #endregion
        Hosman123Context dbContext = new Hosman123Context();
        public List<HoaDonDien> GetAllItems()
        {
            return dbContext.HoaDonDiens.ToList();
        }
        public bool PostNewItem(HoaDonDien item)
        {
            dbContext.HoaDonDiens.Add(item);
            return dbContext.SaveChanges() > 0;
        }
        public HoaDonDien GetItemByID(string maHoaDon)
        {
            HoaDonDien hoaDonDien = dbContext.HoaDonDiens.Where(x => x.MaHoaDon.Equals(maHoaDon)).FirstOrDefault();
            return hoaDonDien;
        }
        public bool ItemExistsByID(string maHoaDon)
        {
            return dbContext.HoaDonDiens.Any(e => e.MaHoaDon == maHoaDon);
        }
        public bool RemoveItem(string maHoaDon)
        {
            HoaDonDien hoaDonDien = dbContext.HoaDonDiens.Where(x => x.MaHoaDon.Equals(maHoaDon)).FirstOrDefault();
            if (hoaDonDien != null)
            {
                dbContext.HoaDonDiens.Remove(hoaDonDien);
                return dbContext.SaveChanges() > 0;
            }
            else
                return false;
        }
        public bool PutItem(HoaDonDien updateItem)
        {
            dbContext.Entry(updateItem).State = EntityState.Modified;
            return true;
        }
    }
}
