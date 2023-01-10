using hosman_api.Models;

namespace hosman_api.Interface
{
    public interface INguoiDungRepository
    {
        public List<NguoiDungModel> GetAllItems();


        public bool PostNewItem(NguoiDungModel newItem);


        public NguoiDungModel GetItemByID(string maNguoiDung);


        public bool RemoveItem(string maNguoiDung);


        public bool PutItem(NguoiDungModel updateItem);
    }
}
