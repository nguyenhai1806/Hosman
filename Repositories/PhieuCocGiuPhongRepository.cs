using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;

namespace hosman_api.Repositories
{
    public class PhieuCocGiuPhongRepository : IPhieuCocGiuPhongRepository
    {
        private readonly Hosman123Context _context;
        private readonly IMapper _mapper;

        public PhieuCocGiuPhongRepository(Hosman123Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
