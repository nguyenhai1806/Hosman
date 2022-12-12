using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;
using hosman_api.Models;

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

        public bool PostNewItem(DanhSachNguoiTro newItem)
        {
            throw new NotImplementedException();
        }

        public DanhSachNguoiTro GetItemByID(string maNguoiTro)
        {
            throw new NotImplementedException();
        }

        public bool RemoveItem(string maNguoiTro)
        {
            throw new NotImplementedException();
        }

        public bool PutItem(DanhSachNguoiTro updateItem)
        {
            throw new NotImplementedException();
        }

        public bool ItemExistsByID(string maNguoiTro)
        {
            throw new NotImplementedException();
        }

        public List<DanhSachNguoiTro> GetItemsByChuTro(string maChuTro)
        {
            throw new NotImplementedException();
        }

        public List<DanhSachNguoiTro> GetItemsByHopDong(string maHopDong)
        {
            throw new NotImplementedException();
        }
    }
}
