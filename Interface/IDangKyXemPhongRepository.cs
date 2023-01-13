using hosman_api.Data;
using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.Interface
{
    public interface IDangKyXemPhongRepository
    {
        public List<DangKyXemPhongModel> GetAllItems();

        public bool PostNewItem(DangKyXemPhongModel newItem);

        public DangKyXemPhongModel GetItemByID(string maDangKy);

        public bool ItemExistsByID(string maDangKy);

        public bool RemoveItem(string maDangKy);
        public List<DangKyXemPhongModel> GetItemsByKhuTro(string maKhuTro);
        public bool PutItem(DangKyXemPhongModel updateItem);


    }
}
