using Atol.NET.Enums;

namespace Atol.NET.Attributes;

public class ParameterIdAttribute : ParamBaseAttribute
{
    public ParameterIdAttribute(Parameter constant, Type returningType) : base(returningType)
    {
        Constant = (int) constant;
    }

    public int Constant { get; }
}