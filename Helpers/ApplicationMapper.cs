using AutoMapper;
using hosman_api.Data;
using hosman_api.Models;

namespace hosman_api.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<DanhSachNguoiTro, DanhSachNguoiTroModel>().ReverseMap();
            CreateMap<BinhLuan, BinhLuanModel>().ReverseMap();
            CreateMap<DangKyXemPhong, DangKyXemPhongModel>().ReverseMap();
            CreateMap<DichVu, DichVuModel>().ReverseMap();
            CreateMap<DmManHinh, DmManHinhModel>().ReverseMap();
            CreateMap<DongHoDien, DongHoDienModel>().ReverseMap();
            CreateMap<DongHoNuoc, DongHoNuocModel>().ReverseMap();
            CreateMap<KhuTro, KhuTroModel>().ReverseMap();
            CreateMap<LoaiPhong, LoaiPhongModel>().ReverseMap();
            CreateMap<PhieuChi, PhieuChiModel>().ReverseMap();
            CreateMap<PhieuCocGiuPhong, PhieuCocGiuPhongModel>().ReverseMap();
            CreateMap<Phong, PhongModel>().ReverseMap();
            CreateMap<TienIch, TienIchModel>().ReverseMap();
            CreateMap<YeuCauSuaChua, YeuCauSuaChuaModel>().ReverseMap();
            CreateMap<HopDongThue, HopDongThueModel>().ReverseMap();
            CreateMap<PhuLuc, PhuLucModel>().ReverseMap();
            CreateMap<DichVuKhuTro, DichVuKhuTroModel>().ReverseMap();
            CreateMap<DichVuPhong, DichVuPhongModel>().ReverseMap();
            CreateMap<NguoiDung, NguoiDungModel>().ReverseMap();
        }
    }
}
