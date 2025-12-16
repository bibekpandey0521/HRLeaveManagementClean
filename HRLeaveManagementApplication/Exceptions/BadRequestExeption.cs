using FluentValidation.Results;

namespace HR.LeaveManagement.Application.Exceptions
{
    public class BadRequestExeption : Exception
    {
        public BadRequestExeption(string message) : base(message)
        {

        }

        public BadRequestExeption(string message,ValidationResult validationResult) : base(message)
        {
            ValidationErrors = new();
            foreach(var error in validationResult.Errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }
        }

        public List<string> ValidationErrors { get; set; }
    }
}
