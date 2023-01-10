using hosman_api.Data;
using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.Interface
{
    public interface IPhieuCocGiuPhongRepository
    {
        public List<PhieuCocGiuPhongModel> GetAllItems();
       
        public bool PostNewItem(PhieuCocGiuPhongModel newItem);
       
        public PhieuCocGiuPhongModel GetItemByID(string maPhieuCoc);
       
        public bool ItemExistsByID(string maPhieuCoc);
       
        public bool PutItem(PhieuCocGiuPhongModel updateItem);
       
        public bool RemoveItem(string maPhieuCoc);
      
    }
}
