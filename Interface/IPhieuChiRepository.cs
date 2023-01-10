using hosman_api.Data;
using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.Interface
{
    public interface IPhieuChiRepository
    {
        public List<PhieuChiModel> GetAllItems();

        public bool PostNewItem(PhieuChiModel newItem);
       
        public PhieuChiModel GetItemByID(string maPhieuChi);
      
        public bool RemoveItem(string maPhieuChi);
       
        public bool PutItem(PhieuChiModel updateItem);
      
    }
}
