using System;
using System.Collections.Generic;

namespace KoiCareSys.Data.Models;

public partial class MeasureDatum
{
    public Guid Id { get; set; }

    public decimal? Volume { get; set; }

    public Guid MeasurementId { get; set; }

    public Guid UnitId { get; set; }

    public virtual Measurement Measurement { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;
}
