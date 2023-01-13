using hosman_api.Models;

namespace hosman_api.Interface
{
    public interface ITienIchRepository
    {
        public List<TienIchModel> GetAllItems();

        public bool PostNewItem(TienIchModel newItem);


        public TienIchModel GetItemByID(string maTienIch);


        public bool RemoveItem(string maTienIch);


        public bool PutItem(TienIchModel updateItem);


        public bool ItemExistsByID(string maTienIch);

        public List<TienIchModel> GetTienIchByKhuTro(string maKhuTro);
        public bool PostTienIchKhuTro(KhuTroTienIch khutroTienIch);
        public bool DeleteTienIchKhuTro(KhuTroTienIch khutroTienIch);
    }
}
