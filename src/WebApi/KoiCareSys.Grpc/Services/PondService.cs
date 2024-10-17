using Grpc.Core;

namespace KoiCareSys.Grpc.Protos
{
    public class PondService : PondManager.PondManagerBase
    {
        public override Task<PondReply> GetPondById(GetPondRequest request, ServerCallContext context)
        {
            var pond = new PondReply
            {
                Id = request.PondId,
                PondName = "Sample Pond",
                Volume = 100.0f,
                Depth = 5.0f,
                DrainCount = 2,
                SkimmerCount = 1,
                PumpCapacity = 15.0f,
                ImgUrl = "http://example.com/pond.png",
                Note = "Sample pond note",
                Description = "Pond description",
                Status = "Active",
                IsQualified = true
            };

            return Task.FromResult(pond);
        }

        public override Task<PondReply> CreatePond(CreatePondRequest request, ServerCallContext context)
        {
            var newPond = new PondReply
            {
                Id = "generated_id",
                PondName = request.PondName,
                Volume = request.Volume,
                Depth = request.Depth,
                DrainCount = request.DrainCount,
                SkimmerCount = request.SkimmerCount,
                PumpCapacity = request.PumpCapacity,
                ImgUrl = request.ImgUrl,
                Note = request.Note,
                Description = request.Description,
                Status = request.Status,
                IsQualified = request.IsQualified
            };

            return Task.FromResult(newPond);
        }

        public override Task<PondReply> UpdatePond(UpdatePondRequest request, ServerCallContext context)
        {
            var updatedPond = new PondReply
            {
                Id = request.PondId,
                PondName = request.PondName,
                Volume = request.Volume,
                Depth = request.Depth,
                DrainCount = request.DrainCount,
                SkimmerCount = request.SkimmerCount,
                PumpCapacity = request.PumpCapacity,
                ImgUrl = request.ImgUrl,
                Note = request.Note,
                Description = request.Description,
                Status = request.Status,
                IsQualified = request.IsQualified
            };

            return Task.FromResult(updatedPond);
        }

        public override Task<DeletePondReply> DeletePond(DeletePondRequest request, ServerCallContext context)
        {
            bool success = true;

            return Task.FromResult(new DeletePondReply { Success = success });
        }
    }
}
