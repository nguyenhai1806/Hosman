using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;
using hosman_api.Models;

namespace hosman_api.Repositories
{
    public class DmManHinhRepository : IDmManHinhRepository
    {
        private readonly Hosman123Context _context;
        private readonly IMapper _mapper;

        public DmManHinhRepository(Hosman123Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<DmManHinhModel> GetAllItems()
        {
            List<DmManHinh> dmManHinhs = _context.DmManHinhs.ToList();
            return _mapper.Map<List<DmManHinhModel>>(dmManHinhs);
        }

        public DmManHinhModel GetItemByID(string maManHinh)
        {
            var dmManHinh = _context.DmManHinhs.Find(maManHinh);
            return _mapper.Map<DmManHinhModel>(dmManHinh);
        }

        public bool ItemExistsByID(string maManHinh)
        {
            return _context.DmManHinhs.Any(e => e.MaManHinh == maManHinh);
        }

        public bool PostNewItem(DmManHinhModel item)
        {
            var dmManHinh = _mapper.Map<DmManHinh>(item);
            _context.DmManHinhs.Add(dmManHinh);
            return _context.SaveChanges() > 0;
        }

        public bool PutItem(DmManHinhModel updateItem)
        {
            DmManHinh dmManHinh = _mapper.Map<DmManHinh>(updateItem);
            _context.DmManHinhs.Update(dmManHinh);
            return _context.SaveChanges() > 0;
        }

        public bool RemoveItem(string maManHinh)
        {
            var dmManHinh = _context.DmManHinhs.Find(maManHinh);
            if (dmManHinh != null)
            {
                _context.DmManHinhs.Remove(dmManHinh);
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
