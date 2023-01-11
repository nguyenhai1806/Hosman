using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;
using hosman_api.Models;

namespace hosman_api.Repositories
{
    public class DichVuPhongRespository : IDichVuPhongRespository
    {
        private readonly Hosman123Context _context;
        private readonly IMapper _mapper;

        public DichVuPhongRespository(Hosman123Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<DichVuPhongModel> GetAllItems()
        {
            List<DichVuPhong> list = _context.DichVuPhongs.ToList();
            return _mapper.Map<List<DichVuPhongModel>>(list);
        }

        public List<DichVuPhongModel> GetAllItemsByPhong(string maPhong)
        {
            List<DichVuPhong> list = _context.DichVuPhongs.Where(d => d.MaPhong == maPhong).ToList();
            return _mapper.Map<List<DichVuPhongModel>>(list);
        }

        public bool PostNewItem(DichVuPhongModel newItem)
        {
            DichVuPhong dichVuPhong = _mapper.Map<DichVuPhong>(newItem);
            _context.DichVuPhongs.Add(dichVuPhong);
            return _context.SaveChanges() > 0;
        }

        public DichVuPhongModel GetItemById(string maDichVu, string maPhong, string maKhuTro)
        {
            DichVuPhong item = _context.DichVuPhongs.Find(maDichVu, maKhuTro, maPhong);
            return _mapper.Map<DichVuPhongModel>(item);
        }

        public bool RemoveItem(string maDichVu, string maPhong, string maKhuTro)
        {
            DichVuPhong item = _context.DichVuPhongs.Find(maDichVu, maPhong, maKhuTro);
            _context.DichVuPhongs.Remove(item);
            return _context.SaveChanges() > 0;
        }

        public bool PutItem(DichVuPhongModel updateItem)
        {
            DichVuPhong item = _mapper.Map<DichVuPhong>(updateItem);
            _context.DichVuPhongs.Update(item);
            return _context.SaveChanges() > 0;
        }
    }
}
