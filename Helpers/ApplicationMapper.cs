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
        }
    }
}
