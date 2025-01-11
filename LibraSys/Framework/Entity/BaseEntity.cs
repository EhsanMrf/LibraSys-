namespace Framework.Entity;

public class BaseEntity<T>
{
    public T Id { get; set; } = default!;
    public DateTime CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
    public bool IsDeleted { get; set; }
}