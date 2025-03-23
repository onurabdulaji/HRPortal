namespace HRPortal.Domain.Interfaces.IBase;

public interface IBaseEntity
{
    public Guid Id { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public bool? Status { get; set; }
}
