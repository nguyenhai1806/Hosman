using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;
using hosman_api.Models;

namespace hosman_api.Repositories
{
    public class DongHoNuocRespository : IDongHoNuocRepository
    {
        private readonly Hosman123Context _context;
        private readonly IMapper _mapper;

        public DongHoNuocRespository(Hosman123Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<DongHoNuocModel> GetAllItems()
        {
            List<DongHoNuoc> dongHoNuocs = _context.DongHoNuocs.ToList();
            return _mapper.Map<List<DongHoNuocModel>>(dongHoNuocs);
        }

        public DongHoNuocModel GetItemByID(string maBanGhi)
        {
            var dongHoNuoc = _context.DongHoNuocs.Find(maBanGhi);
            return _mapper.Map<DongHoNuocModel>(dongHoNuoc);
        }

        public bool ItemExistsByID(string maBanGhi)
        {
            return _context.DongHoNuocs.Any(e => e.MaBanGhi == maBanGhi);
        }

        public bool PostNewItem(DongHoNuocModel item)
        {
            var dongHoNuoc = _mapper.Map<DongHoNuoc>(item);
            _context.DongHoNuocs.Add(dongHoNuoc);
            return _context.SaveChanges() > 0;
        }

        public bool PutItem(DongHoNuocModel updateItem)
        {
            DongHoNuoc dongHoNuoc = _mapper.Map<DongHoNuoc>(updateItem);
            _context.DongHoNuocs.Update(dongHoNuoc);
            return _context.SaveChanges() > 0;
        }

        public bool RemoveItem(string maBanGhi)
        {
            var dongHoNuoc = _context.DongHoNuocs.Find(maBanGhi);
            if (dongHoNuoc != null)
            {
                _context.DongHoNuocs.Remove(dongHoNuoc);
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
