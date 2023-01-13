using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;
using Microsoft.EntityFrameworkCore;

namespace hosman_api.Repositories
{
    public class HoaDonRepository : IHoaDonRepository
    {
        private readonly Hosman123Context _context;
        private readonly IMapper _mapper;

        public HoaDonRepository(Hosman123Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<HoaDon> GetAllItems()
        {
            List<HoaDon> list = _context.HoaDons.ToList();
            return list;
        }
        public List<HoaDon> GetAllItemsByHopDong(string maHopDong)
        {
            return _context.HoaDons.Where((h => h.MaHopDong == maHopDong)).ToList();
        }

        public HoaDon GetItemByID(string maHoaDon)
        {
            HoaDon hd = _context.HoaDons.Include(c => c.HoaDonNuoc).Include(c => c.HoaDonDien)
                .Where(h => h.MaHoaDon == maHoaDon).FirstOrDefault();

            _context.Entry(hd).Collection(h => h.HoaDonDichVus).Load();
            _context.Entry(hd).Collection(h => h.MaPhieuChis);
            return hd;
        }

        public bool PostNewItem(HoaDon hd)
        {
            var dbContextTransaction = _context.Database.BeginTransaction();
            try
            {
                _context.HoaDons.Add(hd);
                int result = _context.SaveChanges();
                dbContextTransaction.Commit();
                return result > 0;
            }
            catch (Exception)
            {
                dbContextTransaction.Rollback();
                return false;
            }
        }
    }
}
