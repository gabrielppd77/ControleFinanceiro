namespace Domain.Base;

public abstract class Entity
{
    public Guid Id { get; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    public void CreateFieldCreatedAt()
    {
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateFieldUpdatedAt()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}
