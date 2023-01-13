using hosman_api.Models;

namespace hosman_api.Interface
{
    public interface IPhuLucRepository
    {
        public bool PostPhuLuc(PhuLucModel newItem);
        public PhuLucModel GetPhuLucByID(string maPhuLuc);
        public bool DeletePhuLuc(string maPhuLuc);
        public List<PhuLucModel> GetPhuLucByHopDong(string maHopDong);
        public bool PutItem(PhuLucModel updateItem);
    }
}
