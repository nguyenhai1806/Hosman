using hosman_api.Models;

namespace hosman_api.DAL
{
    public class HopDongThueDAL
    {
        #region instance

        private static HopDongThueDAL instance;

        public static HopDongThueDAL Instance
        {
            get
            {
                if (instance == null) instance = new HopDongThueDAL();
                return instance;
            }
            private set { instance = value; }
        }

        private HopDongThueDAL()
        {
        }

        #endregion instance

        private Hosman123Context dbContext = new Hosman123Context();

        public bool PostNewItem(HopDongThue hopDong, PhuLuc phuLuc)
        {
            var dbContextTransaction = dbContext.Database.BeginTransaction();
            try
            {
                dbContext.HopDongThues.Add(hopDong);
                dbContext.SaveChanges();

                dbContext.PhuLucs.Add(phuLuc);
                dbContext.SaveChanges();

                dbContextTransaction.Commit();
                return true;
            }
            catch (Exception e)
            {
                dbContextTransaction.Rollback();
                return false;
            }
        }
    }
}
