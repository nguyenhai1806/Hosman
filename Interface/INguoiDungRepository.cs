using hosman_api.Models;

namespace hosman_api.Interface
{
    public interface INguoiDungRepository
    {
        public List<NguoiDungModel> GetAllItems();

        public bool UpdateRefeshToken(string maNguoiDung, string refeshToken);

        public NguoiDungModel GetItemLogin(string email, string password);

        public NguoiDungModel GetItemByRefeshToken(string refeshToken);

        public bool PostNewItem(NguoiDungModel newItem);


        public NguoiDungModel GetItemByID(string maNguoiDung);


        public bool RemoveItem(string maNguoiDung);


        public bool PutItem(NguoiDungModel updateItem);

        
    }
}
