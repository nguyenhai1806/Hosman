using hosman_api.Models;

namespace hosman_api.Interface
{
    public interface IPhongRepository
    {
        public List<PhongModel> GetAllItems();


        public bool PostNewItem(PhongModel newItem);


        public PhongModel GetItemByID(string maPhong);


        public bool RemoveItem(string maPhong);


        public bool PutItem(PhongModel updateItem);
        public List<PhongModel> GetItemsByKhuTro(string maKhuTro);
    }
}
