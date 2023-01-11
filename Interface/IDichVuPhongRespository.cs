using hosman_api.Models;

namespace hosman_api.Interface
{
    public interface IDichVuPhongRespository
    {
        public List<DichVuPhongModel> GetAllItems();
        public List<DichVuPhongModel> GetAllItemsByPhong(string maPhong);
        public bool PostNewItem(DichVuPhongModel newItem);
        public DichVuPhongModel GetItemById(string maDichVu, string maPhong, string maKhuTro);
        public bool RemoveItem(string maDichVu, string maPhong, string maKhuTro);
        public bool PutItem(DichVuPhongModel updateItem);
    }
}
