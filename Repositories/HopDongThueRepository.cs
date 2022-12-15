using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;
using hosman_api.Models;

namespace hosman_api.Repositories;

public class HopDongThueRepository : IHopDongRepository
{
    private readonly Hosman123Context _context;
    private readonly IMapper _mapper;

    public HopDongThueRepository(Hosman123Context context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public bool PostHopDong(HopDongThueModel hopDongModel, PhuLucModel phuLucModel)
    {
        var dbContextTransaction = _context.Database.BeginTransaction();
        try
        {
            HopDongThue hopDong = _mapper.Map<HopDongThue>(hopDongModel);
            PhuLuc phuLuc = _mapper.Map<PhuLuc>(phuLucModel);

            _context.HopDongThues.Add(hopDong);
            _context.SaveChanges();

            _context.PhuLucs.Add(phuLuc);
            _context.SaveChanges();

            dbContextTransaction.Commit();
            return true;
        }
        catch (Exception)
        {
            dbContextTransaction.Rollback();
            return false;
        }
    }
    public List<HopDongThueModel> GetHopDongByPhong(string maPhong)
    {
        return _mapper.Map<List<HopDongThueModel>>(_context.HopDongThues.Where(x => x.MaPhong == maPhong));
    }

    public bool PutHopDong(HopDongThueModel updateItem)
    {
        HopDongThue hopDong = _mapper.Map<HopDongThue>(updateItem);
        _context.HopDongThues.Update(hopDong);
        return _context.SaveChanges() > 0;
    }
    public HopDongThueModel GetHopDongByID(string maHopDong)
    {
        HopDongThue? hopDong = _context.HopDongThues.Find(maHopDong);
        return _mapper.Map<HopDongThueModel>(hopDong);
    }

}