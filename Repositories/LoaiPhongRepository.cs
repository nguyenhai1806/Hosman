using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;
using hosman_api.Models;

namespace hosman_api.Repositories
{
    public class LoaiPhongRepository : ILoaiPhongRepository
    {
        private readonly Hosman123Context _context;
        private readonly IMapper _mapper;

        public LoaiPhongRepository(Hosman123Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<LoaiPhongModel> GetAllItems()
        {
            List<LoaiPhong> loaiPhongs = _context.LoaiPhongs.ToList();
            return _mapper.Map<List<LoaiPhongModel>>(loaiPhongs);
        }

        public bool PostNewItem(LoaiPhongModel newItem)
        {
            var loaiPhong = _mapper.Map<LoaiPhong>(newItem);
            _context.LoaiPhongs.Add(loaiPhong);
            return _context.SaveChanges() > 0;
        }

        public LoaiPhongModel GetItemByID(string maLoaiPhong)
        {
            var loaiPhong = _context.LoaiPhongs.Find(maLoaiPhong);
            return _mapper.Map<LoaiPhongModel>(loaiPhong);
        }

        public bool RemoveItem(string maLoaiPhong)
        {
            var loaiPhong = _context.LoaiPhongs.Find(maLoaiPhong);
            if (loaiPhong != null)
            {
                _context.LoaiPhongs.Remove(loaiPhong);
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }

        public bool PutItem(LoaiPhongModel updateItem)
        {
            LoaiPhong loaiPhong = _context.LoaiPhongs.Find(updateItem.MaLoai);
            loaiPhong.TenLoai = updateItem.TenLoai;
            loaiPhong.GhiChu = updateItem.GhiChu;
            //_context.LoaiPhongs.Update(loaiPhong);
            return _context.SaveChanges() > 0;
        }
    }
}
