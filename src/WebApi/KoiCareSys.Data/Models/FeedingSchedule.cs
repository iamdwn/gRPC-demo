using System;
using System.Collections.Generic;

namespace KoiCareSys.Data.Models;

public partial class FeedingSchedule
{
    public Guid Id { get; set; }

    public DateTime FeedAt { get; set; }

    public decimal? FoodAmount { get; set; }

    public Guid KoiId { get; set; }

    public string? FoodType { get; set; }

    public string? Note { get; set; }

    public virtual Koi Koi { get; set; } = null!;
}
