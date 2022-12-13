using hosman_api.Models;

namespace hosman_api.Interface
{
    public interface IKhuTroRepository
    {
        public List<KhuTroModel> GetAllItems();

        public bool PostNewItem(KhuTroModel newItem);

        public KhuTroModel GetItemByID(string maKhuTro);

        public bool RemoveItem(string maKhuTro);

        public bool PutItem(KhuTroModel updateItem);

        /// <summary>
        /// lấy tất cả khu trọ của chủ trọ
        /// </summary>
        /// <param name="maKhuTro"></param>
        /// <returns></returns>
        public List<KhuTroModel> GetItemsByChuTro(string maChuTro);
    }
}
