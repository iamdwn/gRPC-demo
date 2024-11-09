using System;
using System.Collections.Generic;

namespace KoiCareSys.Data.Models;

public partial class KoiRecord
{
    public Guid Id { get; set; }

    public decimal? Weight { get; set; }

    public DateTime RecordAt { get; set; }

    public decimal? Length { get; set; }

    public string? Physique { get; set; }

    public Guid KoiId { get; set; }

    public Guid DevelopmentStageId { get; set; }

    public virtual DevelopmentStage DevelopmentStage { get; set; } = null!;

    public virtual Koi Koi { get; set; } = null!;
}
