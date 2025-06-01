namespace HeavyApps.Blog.Domain.Model;
public abstract class EntityBase
{
    public Guid ID { get; set; } = Guid.NewGuid();

    protected EntityBase()
    {
        //Id = Guid.NewGuid();
    }
}
