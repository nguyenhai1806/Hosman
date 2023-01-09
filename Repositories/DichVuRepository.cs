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

        public bool PostNewItem(DichVuModel newItem)
        {
            DichVu dichVu = _mapper.Map<DichVu>(newItem);
            _context.DichVus.Add(dichVu);
            return _context.SaveChanges() > 0;
        }

        public DichVuModel GetItemByID(string maDichVu)
        {
            DichVu dichVu = _context.DichVus.Find(maDichVu);
            return _mapper.Map<DichVuModel>(dichVu);
        }

        public bool RemoveItem(string maDichVu)
        {
            DichVu dichVu = _context.DichVus.Find(maDichVu);
            _context.DichVus.Remove(dichVu);
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
    }
}
