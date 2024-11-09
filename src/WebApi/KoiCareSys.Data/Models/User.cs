using System.Text.Json.Serialization;

namespace KoiCareSys.Data.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string? Password { get; set; }

    public string Email { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public int Status { get; set; }

    public string? PhoneNumber { get; set; }

    public int Role { get; set; }

    [JsonIgnore]
    public virtual ICollection<Pond> Ponds { get; set; } = new List<Pond>();
}
