using Atol.NET.Enums;

namespace Atol.NET.Attributes;

public class ConstantAttribute : ParamBaseAttribute
{
    public ConstantAttribute(Parameter constant, Type returningType) : base(returningType)
    {
        Constant = (int) constant;
    }

    public int Constant { get; }
}