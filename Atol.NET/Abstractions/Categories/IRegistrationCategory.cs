using Atol.NET.Models.Registrations;
using Atol.NET.Models.Responses;

namespace Atol.NET.Abstractions.Categories;

public interface IRegistrationCategory
{
    KktBaseResponse Register(RegistrationSettings settings);
    
    KktBaseResponse ReRegister(RegistrationSettings settings);

    KktBaseResponse CloseFiscalStorage(bool printReport);
}