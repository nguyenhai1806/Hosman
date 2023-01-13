using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;
using hosman_api.Models;

namespace hosman_api.Repositories
{

    public class DichVuKhuTroRepository : IDichVuKhuTroRespository
    {
        private readonly Hosman123Context _context;
        private readonly IMapper _mapper;

        public DichVuKhuTroRepository(Hosman123Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<DichVuKhuTroModel> GetAllItems()
        {
            List<DichVuKhuTro> list = _context.DichVuKhuTros.ToList();
            return _mapper.Map<List<DichVuKhuTroModel>>(list);
        }

        public List<DichVuKhuTroModel> GetAllItemsByKhuTro(string maKhuTro)
        {
            List<DichVuKhuTro> list = _context.DichVuKhuTros.Where(d => d.MaKhuTro == maKhuTro).ToList();
            return _mapper.Map<List<DichVuKhuTroModel>>(list);
        }

        public bool PostNewItem(DichVuKhuTroModel newItem)
        {
            DichVuKhuTro dichVuKhuTro = _mapper.Map<DichVuKhuTro>(newItem);
            _context.DichVuKhuTros.Add(dichVuKhuTro);
            return _context.SaveChanges() > 0;
        }

        public DichVuKhuTroModel GetItemByID(string maDichVu, string maKhuTro)
        {
            DichVuKhuTro dichVuKhuTro = _context.DichVuKhuTros.Find(maDichVu, maKhuTro);
            return _mapper.Map<DichVuKhuTroModel>(dichVuKhuTro);
        }

        public bool RemoveItem(string maDichVu, string maKhuTro)
        {
            DichVuKhuTro dichVuKhuTro = _context.DichVuKhuTros.Find(maDichVu, maKhuTro);
            _context.DichVuKhuTros.Remove(dichVuKhuTro);
            return _context.SaveChanges() > 0;
        }

        public bool PutItem(DichVuKhuTroModel updateItem)
        {
            DichVuKhuTro dichVuKhuTro = _context.DichVuKhuTros.Find(updateItem.MaDichVu, updateItem.MaKhuTro);
            dichVuKhuTro.DonGia = updateItem.DonGia;
            //_context.DichVuKhuTros.Update(dichVuKhuTro);
            return _context.SaveChanges() > 0;
        }
    }
}
