using hosman_api.Models;

namespace hosman_api.DAL
{
    public class QlNhomNguoiDungDAL
    {
        #region instance

        private static QlNhomNguoiDungDAL instance;

        public static QlNhomNguoiDungDAL Instance
        {
            get
            {
                if (instance == null) instance = new QlNhomNguoiDungDAL();
                return instance;
            }
            private set { instance = value; }
        }

        private QlNhomNguoiDungDAL()
        {
        }

        #endregion

        Hosman123Context dbContext = new Hosman123Context();
        public List<QlNhomNguoiDung> GetAllItems()
        {
            return dbContext.QlNhomNguoiDungs.ToList();
        }
        public bool PostNewItem(QlNhomNguoiDung newItem)
        {
            dbContext.QlNhomNguoiDungs.Add(newItem);
            return dbContext.SaveChanges() > 0;
        }
        public QlNhomNguoiDung GetItemByID(string maNhom)
        {
            QlNhomNguoiDung qlNhomNguoiDung = dbContext.QlNhomNguoiDungs.Where(x => x.MaNhom.Equals(maNhom)).FirstOrDefault();
            return qlNhomNguoiDung;
        }
        public bool ItemExistsByID(string maNhom)
        {
            return dbContext.QlNhomNguoiDungs.Any(e => e.MaNhom == maNhom);
        }
        public bool ItemExistsByName(string tenNhom)
        {
            return dbContext.QlNhomNguoiDungs.Any(e => e.TenNhom == tenNhom);
        }
        public bool RemoveItem(string maNhom)
        {
            QlNhomNguoiDung qlNhomNguoiDung = dbContext.QlNhomNguoiDungs.Where(x => x.MaNhom.Equals(maNhom)).FirstOrDefault();
            if (qlNhomNguoiDung != null)
            {
                dbContext.QlNhomNguoiDungs.Remove(qlNhomNguoiDung);
                return dbContext.SaveChanges() > 0;
            }
            else
                return false;
        }
    }
}
