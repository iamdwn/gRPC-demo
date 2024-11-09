using System;
using System.Collections.Generic;

namespace KoiCareSys.Data.Models;

public partial class DevelopmentStage
{
    public Guid Id { get; set; }

    public string? StageName { get; set; }

    public decimal? RequiredFoodAmount { get; set; }

    public virtual ICollection<KoiRecord> KoiRecords { get; set; } = new List<KoiRecord>();
}
