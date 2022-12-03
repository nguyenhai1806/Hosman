using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.DAL
{
    public class KhuTroDAL
    {
        #region instance

        private static KhuTroDAL instance;

        public static KhuTroDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhuTroDAL();
                return instance;
            }
            private set { instance = value; }
        }

        private KhuTroDAL()
        {
        }

        #endregion instance

        private Hosman123Context dbContext = new Hosman123Context();

        public List<KhuTro> GetAllItems()
        {
            return dbContext.KhuTros.ToList();
        }

        public bool PostNewItem(KhuTro newItem)
        {
            dbContext.KhuTros.Add(newItem);
            return dbContext.SaveChanges() > 0;
        }

        public KhuTro GetItemByID(string maKhuTro)
        {
            return dbContext.KhuTros.SingleOrDefault(x => x.MaKhuTro == maKhuTro);
        }

        public bool RemoveItem(string maKhuTro)
        {
            KhuTro khutro = dbContext.KhuTros.SingleOrDefault(x => x.MaKhuTro == maKhuTro);
            dbContext.KhuTros.Remove(khutro);
            return dbContext.SaveChanges() > 0;
        }

        public bool PutItem(KhuTro updateItem)
        {
            dbContext.Entry(updateItem).State = EntityState.Modified;
            return true;
        }

        /// <summary>
        /// Kiểm tra xem chủ trọ đó có 
        /// </summary>
        /// <param name="maKhuTro"></param>
        /// <returns></returns>
        public List<KhuTro> GetItemsByChuTro(string maChuTro)
        {
            return dbContext.KhuTros.Where(x => x.MaNguoiDung == maChuTro).ToList();
        }
    }
}