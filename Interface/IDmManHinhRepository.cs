using hosman_api.Data;
using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.Interface
{
    public interface IDmManHinhRepository
    {
        public List<DmManHinhModel> GetAllItems();
        
        public bool PostNewItem(DmManHinhModel item);
        
        public DmManHinhModel GetItemByID(string maManHinh);
        
        public bool ItemExistsByID(string maManHinh);
        
        public bool RemoveItem(string maManHinh);
        
        public bool PutItem(DmManHinhModel updateItem);
    }
}
