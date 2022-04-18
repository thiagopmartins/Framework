using FluentValidation.Results;

namespace FrameworkTestApi.Application.Core.Response
{
    public abstract class ResponseBase
    {
        public ValidationResult ValidationResult;

        public ResponseBase()
        {
            ValidationResult = new ValidationResult();
        }

        public void AddError(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }
    }
}
