
using hosman_api.Data;
using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.Interface
{
    public interface IYeuCauSuaChuaRepository
    {
        public List<YeuCauSuaChuaModel> GetAllItems();
       
        public bool PostNewItem(YeuCauSuaChuaModel newItem);
        
        public YeuCauSuaChuaModel GetItemByID(string maYeuCau);
       
        public bool ItemExistsByID(string maYeuCau);
        
        public bool PutItem(YeuCauSuaChuaModel updateItem);
        
        public bool RemoveItem(string maYeuCau);
      
    }
}
