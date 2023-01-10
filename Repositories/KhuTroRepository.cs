using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;
using hosman_api.Models;

namespace hosman_api.Repositories
{
    public class KhuTroRepository : IKhuTroRepository
    {
        private readonly Hosman123Context _context;
        private readonly IMapper _mapper;

        public KhuTroRepository(Hosman123Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public KhuTroRepository()
        {
        }

        public List<KhuTroModel> GetAllItems()
        {
            List<KhuTro> khuTros = _context.KhuTros.ToList();
            return _mapper.Map<List<KhuTroModel>>(khuTros);
        }

        public bool PostNewItem(KhuTroModel newItem)
        {
            var khuTro = _mapper.Map<KhuTro>(newItem);
            _context.KhuTros.Add(khuTro);
            return _context.SaveChanges() > 0;
        }

        public KhuTroModel GetItemByID(string maKhuTro)
        {
            var khuTro = _context.KhuTros.Find(maKhuTro);
            return _mapper.Map<KhuTroModel>(khuTro);
        }

        public bool RemoveItem(string maKhuTro)
        {
            var khuTro = _context.KhuTros.Find(maKhuTro);
            if (khuTro != null)
            {
                _context.KhuTros.Remove(khuTro);
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }

        public bool PutItem(KhuTroModel updateItem)
        {
            KhuTro khuTro = _mapper.Map<KhuTro>(updateItem);
            _context.KhuTros.Update(khuTro);
            return _context.SaveChanges() > 0;
        }

        public List<KhuTroModel> GetItemsByChuTro(string maChuTro)
        {
            List<KhuTro> khuTros = _context.KhuTros.Where(x => x.MaNguoiDung == maChuTro).ToList();
            return _mapper.Map<List<KhuTroModel>>(khuTros);
        }
    }
}
