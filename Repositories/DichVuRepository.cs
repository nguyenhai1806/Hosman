using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;

namespace hosman_api.Repositories
{
    public class DichVuRepository : IDichVuRepository
    {
        private readonly Hosman123Context _context;
        private readonly IMapper _mapper;

        public DichVuRepository(Hosman123Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
