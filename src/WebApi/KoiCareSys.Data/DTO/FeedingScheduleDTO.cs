namespace KoiCareSys.Data.DTO
{
    public class FeedingScheduleDTO
    {
        public DateTime FeedAt { get; set; }
        public decimal? FoodAmount { get; set; }
        public string? FoodType { get; set; }
        public string? Note { get; set; }
        public Guid KoiId { get; set; }
    }
}
