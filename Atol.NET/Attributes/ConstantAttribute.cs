namespace Atol.NET.Attributes;

public class ConstantAttribute : ParamBaseAttribute
{
    public ConstantAttribute(int constant, Type returningType) : base(returningType)
    {
        Constant = constant;
    }

    public int Constant { get; }
}