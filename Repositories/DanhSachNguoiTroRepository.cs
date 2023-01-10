using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;
using hosman_api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.Repositories
{
    public class DanhSachNguoiTroRepository : IDanhSachNguoiTroRepository
    {
        private readonly Hosman123Context _context;
        private readonly IMapper _mapper;

        public DanhSachNguoiTroRepository(Hosman123Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<DanhSachNguoiTroModel> GetAllItems()
        {
            List<DanhSachNguoiTro> danhSachNguoiTros = _context.DanhSachNguoiTros!.ToList();
            return _mapper.Map<List<DanhSachNguoiTroModel>>(danhSachNguoiTros);
        }

        public bool PostNewItem(DanhSachNguoiTroModel newItem)
        {
            var danhSachNguoiTro = _mapper.Map<DanhSachNguoiTro>(newItem);
            _context.DanhSachNguoiTros.Add(danhSachNguoiTro);
            return _context.SaveChanges() > 0;
        }

        public DanhSachNguoiTroModel GetItemByID(string maNguoiTro)
        {
            var danhSachNguoiTro = _context.DanhSachNguoiTros.Find(maNguoiTro);
            return _mapper.Map<DanhSachNguoiTroModel>(danhSachNguoiTro);
        }

        public bool RemoveItem(string maNguoiTro)
        {
            var danhSachNguoiTro = _context.DanhSachNguoiTros.Find(maNguoiTro);
            if (danhSachNguoiTro != null)
            {
                _context.DanhSachNguoiTros.Remove(danhSachNguoiTro);
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }

        public bool PutItem(DanhSachNguoiTroModel updateItem)
        {
            DanhSachNguoiTro danhSachNguoiTro = _mapper.Map<DanhSachNguoiTro>(updateItem);
            _context.DanhSachNguoiTros.Update(danhSachNguoiTro);
            return _context.SaveChanges() > 0;
        }

        public bool ItemExistsByID(string maNguoiTro)
        {
            return _context.DanhSachNguoiTros.Any(e => e.MaNguoiTro == maNguoiTro);
        }

        public List<DanhSachNguoiTroModel> GetItemsByChuTro(string maChuTro)
        {
            var list =
                 from nguoiDung in _context.NguoiDungs.Where(n => n.MaNguoiDung == maChuTro).AsEnumerable()
                 join k in _context.KhuTros on nguoiDung.MaNguoiDung equals k.MaNguoiDung
                 join p in _context.Phongs on k.MaKhuTro equals p.MaKhuTro
                 join h in _context.HopDongThues on p.MaPhong equals h.MaPhong
                 join nguoiTro in _context.DanhSachNguoiTros on h.MaHopDong equals nguoiTro.MaHopDong
                 select nguoiTro;
            return _mapper.Map<List<DanhSachNguoiTroModel>>(list);
        }

        public List<DanhSachNguoiTroModel> GetItemsByHopDong(string maHopDong)
        {
           
            List<DanhSachNguoiTro> list = _context.DanhSachNguoiTros.Where(x => x.MaHopDong == maHopDong).ToList();
            return _mapper.Map<List<DanhSachNguoiTroModel>>(list);
        }
    }
}
