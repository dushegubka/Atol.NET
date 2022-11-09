namespace Atol.NET.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class ParamBaseAttribute : Attribute
{
    protected ParamBaseAttribute(Type returningType)
    {
        ReturningType = returningType;
    }

    public Type ReturningType { get; }
}