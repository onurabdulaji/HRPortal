using HRPortal.Domain.Enums;

namespace HRPortal.Domain.Entities;

public class AppRole : BaseEntity
{
    public string? Title { get; set; }
    public Roles Roles { get; set; }
    public ICollection<AppUser>? Users { get; set; }
}
