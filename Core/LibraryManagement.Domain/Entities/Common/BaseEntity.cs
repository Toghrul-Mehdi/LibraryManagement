namespace LibraryManagement.Domain.Entities.Common;
public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;
}
