using hosman_api.Models;

namespace hosman_api.Interface;

public interface IHopDongRepository
{
    public bool PostHopDong(HopDongThueModel hopDongModel, PhuLucModel phuLucModel);
    public List<HopDongThueModel> GetHopDongByPhong(string maPhong);
    public bool PutHopDong(HopDongThueModel hopDongThueModel);
    public HopDongThueModel GetHopDongByID(string maHopDong);

}