using System.Collections.Generic;
using FlandersOpen.Application.Core;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlandersOpen.Portal.Controllers
{
    public class BaseController : Controller
    {
        protected new IActionResult Ok()
        {
            return base.Ok(Envelope.Ok());
        }

        protected IActionResult Ok<T>(T result)
        {
            return base.Ok(Envelope.Ok(result));
        }

        protected IActionResult Error(string errorMessage)
        {
            return BadRequest(Envelope.Error(errorMessage));
        }

        protected IActionResult FromResult(Result result)
        {
            return result.IsSuccess ? Ok() : Error(result.Error);
        }

        protected IActionResult FromValidation(Dictionary<string, IList<string>> validationMessages)
        {
            return base.Ok(Envelope.Invalid(validationMessages));
        }
    }
}
