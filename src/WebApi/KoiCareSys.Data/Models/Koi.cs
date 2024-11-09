using System;
using System.Collections.Generic;

namespace KoiCareSys.Data.Models;

public partial class Koi
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Physique { get; set; } = null!;

    public int Age { get; set; }

    public decimal Length { get; set; }

    public int Sex { get; set; }

    public string? Category { get; set; }

    public DateOnly InPondSince { get; set; }

    public decimal? PurchasePrice { get; set; }

    public int Status { get; set; }

    public string? ImgUrl { get; set; }

    public string? Origin { get; set; }

    public string? Breed { get; set; }

    public Guid PondId { get; set; }

    public virtual ICollection<FeedingSchedule> FeedingSchedules { get; set; } = new List<FeedingSchedule>();

    public virtual ICollection<KoiRecord> KoiRecords { get; set; } = new List<KoiRecord>();

    public virtual Pond Pond { get; set; } = null!;
}
