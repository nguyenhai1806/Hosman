using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;
using hosman_api.Models;

namespace hosman_api.Repositories
{
    public class DichVuRepository : IDichVuRepository
    {
        private readonly Hosman123Context _context;
        private readonly IMapper _mapper;

        public DichVuRepository(Hosman123Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<DichVuModel> GetAllItems()
        {
            List<DichVu> dichVus = _context.DichVus.ToList();
            return _mapper.Map<List<DichVuModel>>(dichVus);
        }
        public DichVuModel GetItemByID(string maDichVu)
        {
            var dichVu = _context.DichVus.Find(maDichVu);
            return _mapper.Map<DichVuModel>(dichVu);
        }
        public bool ItemExistsByID(string maDichVu)
        {
            return _context.DichVus.Any(e => e.MaDichVu == maDichVu);
        }
        public bool PostNewItem(DichVuModel item)
        {
            var dichVu = _mapper.Map<DichVu>(item);
            _context.DichVus.Add(dichVu);
            return _context.SaveChanges() > 0;
        }
        public bool PutItem(DichVuModel updateItem)
        {
            DichVu dichVu = _context.DichVus.Find(updateItem.MaDichVu);
            dichVu.TenDichVu = updateItem.TenDichVu;
            dichVu.DonViTinh = updateItem.DonViTinh;
            _context.DichVus.Update(dichVu);
            return _context.SaveChanges() > 0;
        }
        public bool RemoveItem(string maDichVu)
        {
            var dichVu = _context.DichVus.Find(maDichVu);
            if (dichVu != null)
            {
                _context.DichVus.Remove(dichVu);
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
