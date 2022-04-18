using FrameworkTestApi.Application.Core.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FrameworkTestApi.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> Errors = new List<string>();

        private ActionResult ReturnBadRequest()
        {
            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", Errors.ToArray() },
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);

            foreach (var error in errors)
            {
                AddProcessorError(error.ErrorMessage);
            }

            return ReturnBadRequest();
        }

        protected ActionResult CustomResponse(ResponseBase response)
        {
            foreach (var error in response.ValidationResult.Errors)
            {
                AddProcessorError(error.ErrorMessage);
            }

            if (OperationIsValid())
            {
                return Ok(response);
            }

            return ReturnBadRequest();
        }

        protected bool OperationIsValid()
        {
            return !Errors.Any();
        }

        protected void AddProcessorError(string error)
        {
            Errors.Add(error);
        }

        protected void ClearProcessorErrors()
        {
            Errors.Clear();
        }
    }
}
