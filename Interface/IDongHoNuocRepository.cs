using hosman_api.Data;
using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.Interface
{
    public interface IDongHoNuocRepository
    {
        public List<DongHoNuocModel> GetAllItems();
      
        public bool PostNewItem(DongHoNuocModel item);
        
        public DongHoNuocModel GetItemByID(string maBanGhi);
       
        public bool ItemExistsByID(string maBanGhi);
        
        public bool RemoveItem(string maBanGhi);
         
        public bool PutItem(DongHoNuocModel updateItem);
        public List<DongHoNuocModel> GetDongHoNuocByPhong(string maPhong);

    }
}
