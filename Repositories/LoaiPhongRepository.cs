using AutoMapper;
using hosman_api.Data;
using hosman_api.Interface;
using hosman_api.Models;

namespace hosman_api.Repositories
{
    public class LoaiPhongRepository : ILoaiPhongRepository
    {
        private readonly Hosman123Context _context;
        private readonly IMapper _mapper;

        public LoaiPhongRepository(Hosman123Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<LoaiPhongModel> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public bool PostNewItem(LoaiPhongModel newItem)
        {
            throw new NotImplementedException();
        }

        public LoaiPhongModel GetItemByID(string maLoaiPhong)
        {
            throw new NotImplementedException();
        }

        public bool RemoveItem(string maLoaiPhong)
        {
            throw new NotImplementedException();
        }

        public bool PutItem(LoaiPhongModel updateItem)
        {
            throw new NotImplementedException();
        }
    }
}
