namespace KoiCareSys.WebApp.Model
{
    public class PondDto

    {
        public Guid Id { get; set; }
        public String PondName { get; set; } = String.Empty;
        public decimal? Volume { get; set; }
        public decimal? Depth { get; set; }
        public int? DrainCount { get; set; }
        public int? SkimmerCount { get; set; }
        public decimal? PumpCapacity { get; set; }
        public string ImgUrl { get; set; }
        public string Note { get; set; }
        public string Description { get; set; }
        public PondStatus Status { get; set; }
        public bool? IsQualified { get; set; }
        public Guid UserId { get; set; }
    }
}
