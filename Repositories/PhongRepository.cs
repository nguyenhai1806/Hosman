using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;

namespace hosman_api.Repositories
{
    public class PhongRepository : IPhongRepository
    {
        private readonly Hosman123Context _context;
        private readonly IMapper _mapper;

        public PhongRepository(Hosman123Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
