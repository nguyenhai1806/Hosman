using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.DAL
{
    public class Template
    {
        #region instance

        private static Template instance;

        public static Template Instance
        {
            get
            {
                if (instance == null) instance = new Template();
                return instance;
            }
            private set { instance = value; }
        }

        private Template()
        {
        }

        #endregion instance

        private Hosman123Context dbContext = new Hosman123Context();

        public List<nuint> GetAllItems()
        {
            return null;
        }

        public bool PostNewItem(nuint newItem)
        {
            return true;
        }

        public DanhSachNguoiTro GetItemByID(string id)
        {
            return null;
        }

        public bool RemoveItem(string id)
        {
            return true;
        }

        public bool PutItem(uint updateItem)
        {
            dbContext.Entry(updateItem).State = EntityState.Modified;
            return true;
        }

        public bool ItemExistsByID(string id)
        {
            return true;
        }
    }
}
