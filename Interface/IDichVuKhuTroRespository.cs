using hosman_api.Models;

namespace hosman_api.Interface
{
    public interface IDichVuKhuTroRespository
    {
        public List<DichVuKhuTroModel> GetAllItems();
        public List<DichVuKhuTroModel> GetAllItemsByKhuTro(string maKhuTro);
        public bool PostNewItem(DichVuKhuTroModel newItem);
        public DichVuKhuTroModel GetItemByID(string maDichVu, string maKhuTro);
        public bool RemoveItem(string maDichVu, string maKhuTro);
        public bool PutItem(DichVuKhuTroModel updateItem);
    }
}
