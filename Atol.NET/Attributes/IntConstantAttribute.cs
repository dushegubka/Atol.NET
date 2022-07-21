namespace Atol.NET.Attributes;

public class IntConstantAttribute : ParamBaseAttribute
{
    public IntConstantAttribute(int constant, Type returningType) : base(returningType)
    {
        Constant = constant;
    }

    public int Constant { get; }
}