using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;
using hosman_api.Models;

namespace hosman_api.Repositories
{
    public class DongHoDienRepository : IDongHoDienRepository
    {
        private readonly Hosman123Context _context;
        private readonly IMapper _mapper;

        public DongHoDienRepository(Hosman123Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<DongHoDienModel> GetAllItems()
        {
            List<DongHoDien> dongHoDiens = _context.DongHoDiens.ToList();
            return _mapper.Map<List<DongHoDienModel>>(dongHoDiens);
        }

        public DongHoDienModel GetItemByID(string maBanGhi)
        {
            var dongHoDien = _context.DongHoDiens.Find(maBanGhi);
            return _mapper.Map<DongHoDienModel>(dongHoDien);
        }

        public bool ItemExistsByID(string maBanGhi)
        {
            return _context.DongHoDiens.Any(e => e.MaBanGhi == maBanGhi);
        }

        public bool PostNewItem(DongHoDienModel item)
        {
            var dongHoDien = _mapper.Map<DongHoDien>(item);
            _context.DongHoDiens.Add(dongHoDien);
            return _context.SaveChanges() > 0;
        }

        public bool PutItem(DongHoDienModel updateItem)
        {
            DongHoDien dongHoDien = _mapper.Map<DongHoDien>(updateItem);
            _context.DongHoDiens.Update(dongHoDien);
            return _context.SaveChanges() > 0;
        }

        public bool RemoveItem(string maBanGhi)
        {
            var dongHoDien = _context.DongHoDiens.Find(maBanGhi);
            if (dongHoDien != null)
            {
                _context.DongHoDiens.Remove(dongHoDien);
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
