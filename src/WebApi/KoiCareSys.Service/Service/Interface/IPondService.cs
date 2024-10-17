using KoiCareSys.Data.DTO;
using KoiCareSys.Data.Models;
using KoiCareSys.Serivice.Base;

namespace KoiCareSys.Service.Service.Interface
{
    public interface IPondService
    {
        //Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetAll(String? search);
        Task<IBusinessResult> GetById(Guid code);
        Task<IBusinessResult> Create(PondDTO dto);
        Task<IBusinessResult> DeleteById(Guid id);
        Task<IBusinessResult> Update(PondDTO dto);
        Task<List<Pond>> GetODataAll();
    }
}
