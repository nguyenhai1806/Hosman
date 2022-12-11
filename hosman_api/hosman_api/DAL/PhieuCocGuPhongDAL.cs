using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.DAL
{
    public class PhieuCocGiuPhongDAL
    {
        #region instance

        private static PhieuCocGiuPhongDAL instance;

        public static PhieuCocGiuPhongDAL Instance
        {
            get
            {
                if (instance == null) instance = new PhieuCocGiuPhongDAL();
                return instance;
            }
            private set { instance = value; }
        }

        private PhieuCocGiuPhongDAL()
        {
        }

        #endregion

        Hosman123Context dbContext = new Hosman123Context();
        public List<PhieuCocGiuPhong> GetAllItems()
        {
            return dbContext.PhieuCocGiuPhongs.ToList();
        }
        public bool PostNewItem(PhieuCocGiuPhong newItem)
        {
            dbContext.PhieuCocGiuPhongs.Add(newItem);
            return dbContext.SaveChanges() > 0;
        }
        public PhieuCocGiuPhong GetItemByID(string maPhieuCoc)
        {
            PhieuCocGiuPhong phieuCocGiuPhong = dbContext.PhieuCocGiuPhongs.Where(x => x.MaPhieuCoc.Equals(maPhieuCoc)).FirstOrDefault();
            return phieuCocGiuPhong;
        }
        public bool ItemExistsByID(string maPhieuCoc)
        {
            return dbContext.PhieuCocGiuPhongs.Any(e => e.MaPhieuCoc == maPhieuCoc);
        }
        public bool PutItem(PhieuCocGiuPhong updateItem)
        {
            dbContext.Entry(updateItem).State = EntityState.Modified;
            return dbContext.SaveChanges() > 0;
        }

        public bool RemoveItem(string maPhieuCoc)
        {
            PhieuCocGiuPhong phieuCocGiuPhong = dbContext.PhieuCocGiuPhongs.Where(x => x.MaPhieuCoc.Equals(maPhieuCoc)).FirstOrDefault();
            if (phieuCocGiuPhong != null)
            {
                dbContext.PhieuCocGiuPhongs.Remove(phieuCocGiuPhong);
                return dbContext.SaveChanges() > 0;
            }
            else
                return false;
        }
    }
}
