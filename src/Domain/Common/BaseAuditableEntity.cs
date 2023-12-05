namespace AppointMateApi.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public BaseAuditableEntity()
    {
        IsDeleted = false;
        Created = DateTimeOffset.UtcNow;
    }

    public DateTimeOffset Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool IsDeleted { get; set; }
}
