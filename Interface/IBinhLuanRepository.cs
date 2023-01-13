using hosman_api.Data;
using hosman_api.Models;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.Interface
{
    public interface IBinhLuanRepository
    {
        public List<BinhLuanModel> GetAllItems();

        public bool PostNewItem(BinhLuanModel item);

        public BinhLuanModel GetItemByID(string maBinhLuan);

        public bool ItemExistsByID(string maBinhLuan);

        public bool RemoveItem(string maBinhLuan);
        public bool PutItem(BinhLuanModel updateItem);


    }
}
