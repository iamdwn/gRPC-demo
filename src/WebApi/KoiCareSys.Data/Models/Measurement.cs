using System;
using System.Collections.Generic;

namespace KoiCareSys.Data.Models;

public partial class Measurement
{
    public Guid MeasurementId { get; set; }

    public DateTime DateRecord { get; set; }

    public string? Note { get; set; }

    public Guid PondId { get; set; }

    public virtual ICollection<MeasureDatum> MeasureData { get; set; } = new List<MeasureDatum>();

    public virtual Pond Pond { get; set; } = null!;
}
