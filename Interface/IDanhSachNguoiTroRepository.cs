using hosman_api.Data;
using hosman_api.Models;

namespace hosman_api.Interface
{
    public interface IDanhSachNguoiTroRepository
    {
        public List<DanhSachNguoiTroModel> GetAllItems();

        public bool PostNewItem(DanhSachNguoiTro newItem);

        public DanhSachNguoiTro GetItemByID(string maNguoiTro);

        public bool RemoveItem(string maNguoiTro);

        public bool PutItem(DanhSachNguoiTro updateItem);

        public bool ItemExistsByID(string maNguoiTro);

        public List<DanhSachNguoiTro> GetItemsByChuTro(string maChuTro);

        public List<DanhSachNguoiTro> GetItemsByHopDong(string maHopDong);

    }
}
