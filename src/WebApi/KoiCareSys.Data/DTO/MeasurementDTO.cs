namespace KoiCareSys.Data.DTO
{
    public class MeasurementDTO
    {
        public Guid MeasurementId { get; set; }

        public Guid PondId { get; set; }

        public DateTime DateRecord { get; set; }

        public List<MeasureDataDTO>? MeasureData { get; set; }

        public string? Note { get; set; }

    }
}

