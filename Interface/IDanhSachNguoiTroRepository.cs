using hosman_api.Models;

namespace hosman_api.Interface
{
    public interface IDanhSachNguoiTroRepository
    {
        public List<DanhSachNguoiTroModel> GetAllItems();

        public bool PostNewItem(DanhSachNguoiTroModel newItem);

        public DanhSachNguoiTroModel GetItemByID(string maNguoiTro);

        public bool RemoveItem(string maNguoiTro);

        public bool PutItem(DanhSachNguoiTroModel updateItem);

        public bool ItemExistsByID(string maNguoiTro);

        public List<DanhSachNguoiTroModel> GetItemsByChuTro(string maChuTro);

        public List<DanhSachNguoiTroModel> GetItemsByHopDong(string maHopDong);

    }
}
