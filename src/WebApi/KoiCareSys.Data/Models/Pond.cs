namespace KoiCareSys.Data.Models;

public partial class Pond
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string PondName { get; set; } = null!;

    public decimal Volume { get; set; }

    public decimal Depth { get; set; }

    public int? DrainCount { get; set; }

    public int? SkimmerCount { get; set; }

    public decimal? PumpCapacity { get; set; }

    public string? ImgUrl { get; set; }

    public Enums.PondStatus Status { get; set; }

    public bool? IsQualified { get; set; }

    public Guid UserId { get; set; }

    public string? Description { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<Koi> Kois { get; set; } = new List<Koi>();

    public virtual ICollection<Measurement> Measurements { get; set; } = new List<Measurement>();

    public virtual User User { get; set; } = null!;
}
