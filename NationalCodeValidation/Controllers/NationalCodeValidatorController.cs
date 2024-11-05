using Microsoft.AspNetCore.Mvc;
using NationalCodeValidation.Extensions;

namespace NationalCodeValidation.Controllers;

public class NationalCodeValidatorController : Controller
{
    [HttpGet]
    public bool ValidateNationalCode([FromBody] string nationalCode)
    {
        return NationalCodeValidator.ValidNationalCode(nationalCode);
    }
}