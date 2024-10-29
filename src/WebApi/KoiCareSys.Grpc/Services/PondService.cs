using Grpc.Core;
using KoiCareSys.Data;
using KoiCareSys.Data.Enums;
using KoiCareSys.Data.Models;
using KoiCareSys.Service.Service.Interface;

namespace KoiCareSys.Grpc.Protos
{
    public class PondService : PondManager.PondManagerBase
    {
        private readonly IPondService _pondService;
        private readonly UnitOfWork _unitOfWork;

        public PondService(IPondService pondService, UnitOfWork unitOfWork)
        {
            _pondService = pondService;
            _unitOfWork = unitOfWork;
        }

        public override async Task<PondReply> GetPondById(GetPondRequest request, ServerCallContext context)
        {

            if (!Guid.TryParse(request.PondId, out Guid pondGuid))
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid PondId format"));
            }

            var result = await _pondService.GetById(pondGuid);

            if (!result.Status.Equals(1) || result.Data == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Pond not found"));
            }
            var pond = result.Data as Pond;

            if (pond == null)
            {
                throw new RpcException(new Status(StatusCode.Internal, "Data type mismatch"));
            }

            return new PondReply
            {
                Id = pond.Id.ToString(),
                PondName = pond.PondName,
                Volume = (float)pond.Volume,
                Depth = (float)pond.Depth,
                DrainCount = pond.DrainCount ?? 0,
                SkimmerCount = pond.SkimmerCount ?? 0,
                PumpCapacity = (float)pond.PumpCapacity,
                ImgUrl = pond.ImgUrl,
                Note = pond.Note,
                Description = pond.Description,
                Status = pond.Status == null ? pond.Status.ToString() : PondStatus.Inactive.ToString(),
                IsQualified = pond.IsQualified ?? false
            };

            //var faker = new Faker<PondReply>("en") // Ensure the locale is set to English
            //.RuleFor(p => p.Id, f => f.Random.Guid().ToString())
            //.RuleFor(p => p.PondName, f => f.Lorem.Word())
            //.RuleFor(p => p.Volume, f => f.Random.Float(50, 500))
            //.RuleFor(p => p.Depth, f => f.Random.Float(2, 10))
            //.RuleFor(p => p.DrainCount, f => f.Random.Int(1, 4))
            //.RuleFor(p => p.SkimmerCount, f => f.Random.Int(0, 2))
            //.RuleFor(p => p.PumpCapacity, f => f.Random.Float(5, 20))
            //.RuleFor(p => p.ImgUrl, f => f.Internet.Url())
            //.RuleFor(p => p.Note, f => f.Lorem.Sentence())
            //.RuleFor(p => p.Description, f => f.Lorem.Paragraph())
            //.RuleFor(p => p.Status, f => f.Random.Bool() ? "Active" : "Inactive")
            //.RuleFor(p => p.IsQualified, f => f.Random.Bool());

            //return await Task.FromResult(pond);
        }

        public override async Task<PondReply> CreatePond(CreatePondRequest request, ServerCallContext context)
        {
            if (string.IsNullOrWhiteSpace(request.PondName))
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Pond name cannot be empty."));
            }

            var newPond = new Data.DTO.PondDTO
            {
                PondName = request.PondName,
                Volume = (decimal)request.Volume,
                Depth = (decimal)request.Depth,
                DrainCount = request.DrainCount,
                SkimmerCount = request.SkimmerCount,
                PumpCapacity = (decimal)request.PumpCapacity,
                ImgUrl = request.ImgUrl,
                Note = request.Note,
                Description = request.Description,
                Status = request.Status.Equals(1) ? PondStatus.Active : PondStatus.Inactive,
                IsQualified = request.IsQualified
            };

            var result = await _pondService.Create(newPond);

            if (!result.Status.Equals(1))
            {
                throw new RpcException(new Status(StatusCode.Internal, "Failed to create pond."));
            }

            var existingPond = _unitOfWork.Pond.GetAllAsync(
               filter: p => p.PondName.Equals(request.PondName)
                ).Result.FirstOrDefault();

            return new PondReply
            {
                Id = existingPond.Id.ToString(),
                PondName = request.PondName,
                Volume = (float)request.Volume,
                Depth = (float)request.Depth,
                DrainCount = request.DrainCount,
                SkimmerCount = request.SkimmerCount,
                PumpCapacity = (float)request.PumpCapacity,
                ImgUrl = request.ImgUrl,
                Note = request.Note,
                Description = request.Description,
                Status = request.Status.Equals(1) ? PondStatus.Active.ToString() : PondStatus.Inactive.ToString(),
                IsQualified = request.IsQualified
            };
        }

        public override async Task<PondReply> UpdatePond(UpdatePondRequest request, ServerCallContext context)
        {
            if (!Guid.TryParse(request.PondId, out Guid pondGuid))
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid PondId format"));
            }

            var pondResult = await _pondService.GetById(pondGuid);

            if (pondResult.Status != 1 || pondResult.Data == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Pond not found"));
            }

            var pond = pondResult.Data as Pond;

            if (pond == null)
            {
                throw new RpcException(new Status(StatusCode.Internal, "Data type mismatch"));
            }

            var updatedPond = new Data.DTO.PondDTO
            {
                Id = pondGuid,
                PondName = request.PondName,
                Volume = (decimal)request.Volume,
                Depth = (decimal)request.Depth,
                DrainCount = request.DrainCount,
                SkimmerCount = request.SkimmerCount,
                PumpCapacity = (decimal)request.PumpCapacity,
                ImgUrl = request.ImgUrl,
                Note = request.Note,
                Description = request.Description,
                Status = request.Status.Equals(1) ? PondStatus.Active : PondStatus.Inactive,
                IsQualified = request.IsQualified,
                UserId = pond.UserId
            };

            await _pondService.Update(updatedPond);

            return new PondReply
            {
                Id = pondGuid.ToString(),
                PondName = updatedPond.PondName,
                Volume = (float)updatedPond.Volume,
                Depth = (float)updatedPond.Depth,
                DrainCount = updatedPond.DrainCount ?? 0,
                SkimmerCount = updatedPond.SkimmerCount ?? 0,
                PumpCapacity = (float)updatedPond.PumpCapacity,
                ImgUrl = updatedPond.ImgUrl,
                Note = updatedPond.Note,
                Description = updatedPond.Description,
                Status = updatedPond.Status == null ? PondStatus.Inactive.ToString() : pond.Status.ToString(),
                IsQualified = updatedPond.IsQualified ?? false
            };
        }


        public override async Task<DeletePondReply> DeletePond(DeletePondRequest request, ServerCallContext context)
        {
            bool success = false;

            try
            {
                if (!Guid.TryParse(request.PondId, out Guid pondGuid))
                {
                    throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid PondId format"));
                }

                var pondResult = await _pondService.GetById(pondGuid);

                if (pondResult.Status != 1 || pondResult.Data == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, "Pond not found"));
                }
                var pond = pondResult.Data as Pond;

                _pondService.DeleteById(pond.Id);
                success = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting pond: {ex.Message}");
            }

            return new DeletePondReply
            {
                Success = success
            };
        }
    }
}
