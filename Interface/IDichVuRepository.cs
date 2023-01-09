using hosman_api.Models;

namespace hosman_api.Interface
{
    public interface IDichVuRepository
    {
        public List<DichVuModel> GetAllItems();
        public bool PostNewItem(DichVuModel newItem);
        public DichVuModel GetItemByID(string id);
        public bool RemoveItem(string maDichVu);
        public bool PutItem(DichVuModel updateItem);
    }
}
