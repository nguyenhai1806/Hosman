using hosman_api.Data;
using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.Interface
{
    public interface ITienIchRepository
    {
        public List<TienIchModel> GetAllItems();
       
        public bool PostNewItem(TienIchModel newItem);
        

        public TienIchModel GetItemByID(string maTienIch);
        

        public bool RemoveItem(string maTienIch);
        

        public bool PutItem(TienIchModel updateItem);
       

        public bool ItemExistsByID(string maTienIch);
       
    }
}
