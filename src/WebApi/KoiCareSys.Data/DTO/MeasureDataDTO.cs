namespace KoiCareSys.Data.DTO
{
    public class MeasureDataDTO
    {
        public Guid MeasureDataId { get; set; }

        public decimal? Volume { get; set; }

        public Guid UnitId { get; set; }
    }
}
