using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.DAL
{
    public class PhongDAL
    {
        #region instance

        private static PhongDAL instance;

        public static PhongDAL Instance
        {
            get
            {
                if (instance == null) instance = new PhongDAL();
                return instance;
            }
            private set { instance = value; }
        }

        private PhongDAL()
        {
        }

        #endregion

        Hosman123Context dbContext = new Hosman123Context();
        public List<Phong> GetAllItems()
        {
            return dbContext.Phongs.ToList();
        }
        public bool PostNewItem(Phong newItem)
        {
            dbContext.Phongs.Add(newItem);
            return dbContext.SaveChanges() > 0;
        }
        public Phong GetItemByID(string maPhong)
        {
            Phong phong = dbContext.Phongs.Where(x => x.MaPhong.Equals(maPhong)).FirstOrDefault();
            return phong;
        }
        public bool ItemExistsByID(string maPhong)
        {
            return dbContext.Phongs.Any(e => e.MaPhong == maPhong);
        }
        public bool PutItem(Phong updateItem)
        {
            dbContext.Entry(updateItem).State = EntityState.Modified;
            return dbContext.SaveChanges() > 0;
        }

        public bool RemoveItem(string maPhong)
        {
            Phong phong = dbContext.Phongs.Where(x => x.MaPhong.Equals(maPhong)).FirstOrDefault();
            if (phong != null)
            {
                dbContext.Phongs.Remove(phong);
                return dbContext.SaveChanges() > 0;
            }
            else
                return false;
        }
    }
}
