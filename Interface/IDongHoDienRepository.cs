using hosman_api.Data;
using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.Interface
{
    public interface IDongHoDienRepository
    {
        public List<DongHoDienModel> GetAllItems();
        
        public bool PostNewItem(DongHoDienModel item);
        
        public DongHoDienModel GetItemByID(string maBanGhi);
        
        public bool ItemExistsByID(string maBanGhi);
       
        public bool RemoveItem(string maBanGhi);
        
        public bool PutItem(DongHoDienModel updateItem);
        public List<DongHoDienModel> GetDongHoDienByPhong(string maPhong);


    }
}
