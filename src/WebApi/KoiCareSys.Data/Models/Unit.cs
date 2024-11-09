using System;
using System.Collections.Generic;

namespace KoiCareSys.Data.Models;

public partial class Unit
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? UnitOfMeasure { get; set; }

    public string? FullName { get; set; }

    public string? Information { get; set; }

    public decimal? MinValue { get; set; }

    public decimal? MaxValue { get; set; }

    public virtual ICollection<MeasureDatum> MeasureData { get; set; } = new List<MeasureDatum>();
}
