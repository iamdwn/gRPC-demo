using AutoMapper;
using KoiCareSys.Common;
using KoiCareSys.Data;
using KoiCareSys.Data.DTO;
using KoiCareSys.Data.Models;
using KoiCareSys.Serivice.Base;
using KoiCareSys.Service.Service.Interface;

namespace KoiCareSys.Service.Service
{
    public class PondService : IPondService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PondService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IBusinessResult> GetAll(String? search)
        {
            try
            {
                var ponds = await _unitOfWork.Pond.GetAllAsync();
                if (ponds == null)
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, "Pond not found");
                else
                    return new BusinessResult(Const.SUCCESS_READ_CODE, "Success", ponds);
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> Create(PondDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    return new BusinessResult(Const.ERROR_EXCEPTION, "request cannot be null.");
                }

                var tempUser = await _unitOfWork.User.GetFirstUser();

                if (tempUser == null)
                {
                    return new BusinessResult(Const.FAIL_CREATE_CODE, "No users not found.");
                }

                var existingPond = await _unitOfWork.Pond.GetAllAsync(filter: n => n.PondName.Equals(dto.PondName));

                if (existingPond.Any())
                {
                    return new BusinessResult(Const.FAIL_CREATE_CODE, "Pond Name is exist.");
                }

                Pond create = new Pond()
                {
                    PondName = dto.PondName,
                    Volume = dto.Volume,
                    Depth = dto.Depth,
                    DrainCount = dto.DrainCount,
                    SkimmerCount = dto.SkimmerCount,
                    PumpCapacity = dto.PumpCapacity,
                    ImgUrl = dto.ImgUrl,
                    Note = dto.Note,
                    Description = dto.Description,
                    Status = dto.Status,
                    IsQualified = dto.IsQualified,
                    //UserId = dto.UserId != null ? dto.UserId : Guid.Empty
                    UserId = tempUser.Id
                };

                if (await _unitOfWork.Pond.CreateAsync(create) > 0)
                    return new BusinessResult(Const.SUCCESS_CREATE_CODE, "Create pond success", create);
                else
                    return new BusinessResult(Const.FAIL_CREATE_CODE, "Create fail");
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.InnerException.Message);
            }
        }

        public async Task<IBusinessResult> GetById(Guid code)
        {
            try
            {
                if (code == null)
                    return new BusinessResult(Const.ERROR_EXCEPTION, "Pond code can not be null");
                var pond = await _unitOfWork.Pond.GetByIdAsync(code);

                if (pond == null)
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, "Pond not found");
                else
                    return new BusinessResult(Const.SUCCESS_READ_CODE, "Success", pond);
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> DeleteById(Guid pondId)
        {
            try
            {
                var pond = await _unitOfWork.Pond.GetByIdAsync(pondId);
                if (pond == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                else
                {
                    var result = await _unitOfWork.Pond.RemoveAsync(pond);
                    if (result)
                    {
                        return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG);
                    }
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        //public async Task<IBusinessResult> GetAll()
        //{
        //    var ponds = await _unitOfWork.Pond.GetAllAsync();
        //    if (ponds == null)
        //    {
        //        return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
        //    }
        //    else
        //    {
        //        var pondDTOs = _mapper.Map<List<PondDTO>>(ponds);
        //        return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, pondDTOs);
        //    }
        //}

        public async Task<IBusinessResult> Update(PondDTO dto)
        {
            Pond pond = _mapper.Map<Pond>(dto);

            try
            {
                int result = -1;

                var existingPond = _unitOfWork.Pond.GetById(dto.Id);

                if (existingPond != null)
                {
                    #region Business rule
                    #endregion Business rule

                    _mapper.Map(dto, existingPond);
                    await _unitOfWork.Pond.UpdateAsync(existingPond);

                    return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, existingPond);

                }
                else
                {
                    return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG, dto);
                }

            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<List<Pond>> GetODataAll()
        {
            #region Business Rule
            #endregion
            var ponds = await _unitOfWork.Pond.GetAllAsync();
            if (ponds == null || !ponds.Any())
            {
                return new List<Pond>();
            }
            return ponds;
        }

    }
}
