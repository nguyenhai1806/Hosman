using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;
using hosman_api.Models;

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

        public List<DichVuModel> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public bool PostNewItem(DichVuModel newItem)
        {
            throw new NotImplementedException();
        }

        public DichVuModel GetItemByID(string id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveItem(string maDichVu)
        {
            throw new NotImplementedException();
        }

        public bool PutItem(DichVuModel updateItem)
        {
            throw new NotImplementedException();
        }
    }
}
