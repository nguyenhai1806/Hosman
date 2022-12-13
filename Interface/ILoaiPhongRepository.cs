using hosman_api.Models;

namespace hosman_api.Interface
{
    public interface ILoaiPhongRepository
    {
        public List<LoaiPhongModel> GetAllItems();


        public bool PostNewItem(LoaiPhongModel newItem);


        public LoaiPhongModel GetItemByID(string maLoaiPhong);


        public bool RemoveItem(string maLoaiPhong);


        public bool PutItem(LoaiPhongModel updateItem);
    }
}
