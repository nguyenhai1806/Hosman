using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;
using hosman_api.Models;

namespace hosman_api.Repositories
{
    public class NguoiDungRepository : INguoiDungRepository
    {
        private readonly Hosman123Context _context;
        private readonly IMapper _mapper;

        public NguoiDungRepository(Hosman123Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<NguoiDungModel> GetAllItems()
        {
            List<NguoiDung> nguoiDungs = _context.NguoiDungs.ToList();
            return _mapper.Map<List<NguoiDungModel>>(nguoiDungs);
        }

        public NguoiDungModel GetItemByID(string maNguoiDung)
        {
            var nguoiDung = _context.NguoiDungs.Find(maNguoiDung);
            return _mapper.Map<NguoiDungModel>(nguoiDung);
        }

        public bool PostNewItem(NguoiDungModel newItem)
        {
            var nguoiDung = _mapper.Map<NguoiDung>(newItem);
            _context.NguoiDungs.Add(nguoiDung);
            return _context.SaveChanges() > 0;
        }

        public bool PutItem(NguoiDungModel updateItem)
        {
            NguoiDung nguoiDung = _context.NguoiDungs.Find(updateItem.MaNguoiDung);
            nguoiDung.GioiTinh = updateItem.GioiTinh;
            nguoiDung.SoDienThoai = updateItem.SoDienThoai;
            nguoiDung.NgaySinh = updateItem.NgaySinh;
            nguoiDung.DiaChi = updateItem.DiaChi;
            nguoiDung.TenNguoiDung = updateItem.TenNguoiDung;
            nguoiDung.Email = updateItem.Email;
            //nguoiDung.MatKhau = updateItem.MatKhau;
            nguoiDung.Cccd = updateItem.Cccd;
            nguoiDung.AnhCccdtruoc = updateItem.AnhCccdtruoc;
            nguoiDung.AnhCccdsau = updateItem.AnhCccdsau;
            nguoiDung.NoiCap = updateItem.NoiCap;
            //_context.NguoiDungs.Update(nguoiDung);
            return _context.SaveChanges() > 0;
        }

        public bool RemoveItem(string maNguoiDung)
        {
            var nguoiDung = _context.NguoiDungs.Find(maNguoiDung);
            if (nguoiDung != null)
            {
                _context.NguoiDungs.Remove(nguoiDung);
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
