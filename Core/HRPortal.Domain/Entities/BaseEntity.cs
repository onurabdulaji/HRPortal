using HRPortal.Domain.Interfaces.IBase;

namespace HRPortal.Domain.Entities;

public abstract class BaseEntity : IBaseEntity
{
    protected BaseEntity()
    {
        CreatedDate = DateTime.Now;
        Status = true;
    }
    public Guid Id { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public bool? Status { get; set; }
}
