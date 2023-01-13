using hosman_api.Data;

namespace hosman_api.Interface
{
    public interface IHoaDonRepository
    {
        public List<HoaDon> GetAllItems();
        public HoaDon GetItemByID(string maHoaDon);
        public bool PostNewItem(HoaDon hd);
    }
}
