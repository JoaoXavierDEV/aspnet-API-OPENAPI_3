namespace HeavyApps.Blog.Domain.Model;
public abstract class EntityBase
{
    public Guid ID { get; set; } = Guid.NewGuid();

    protected EntityBase()
    {
        //Id = Guid.NewGuid();
    }



}

public static class EntityTeste
{
    public static bool IsDefaultValue(this object owner, Type targetType = null)
    {
        if (owner == null)
            return true;
        targetType = targetType ?? owner.GetType();
        object obj = (targetType.IsValueType ? Activator.CreateInstance(targetType) : null);
        return owner.Equals(obj) || Convert.ChangeType(owner, targetType).Equals(obj);
    }



    public static bool IsDefaultValue<T>(this object owner)
    {
        return owner.IsDefaultValue(typeof(T));
    }
}
