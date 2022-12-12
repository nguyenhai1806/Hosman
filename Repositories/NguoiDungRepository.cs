using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;

namespace hosman_api.Repositories
{
    public class NguoiDungRepository : INguoiDungRepository
    {
        private readonly Hosman123Context _context;
        private readonly IMapper _mapper;

        public NguoiDungRepository(Hosman123Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
