using Grpc.Core;

namespace KoiCareSys.Grpc.Protos
{
    public class PondService : PondManager.PondManagerBase
    {
        public override Task<PondReply> GetPondById(GetPondRequest request, ServerCallContext context)
        {
            var pond = new PondReply
            {
                Id = "fixed_id",
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
