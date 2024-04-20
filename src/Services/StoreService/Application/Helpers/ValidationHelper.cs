using FluentValidation.Results;

namespace StoreService.Application.Helpers
{
    public static class ValidationHelper
    {
        public static string GetFirstErrorMessage(this ValidationResult result)
        {
            return result.Errors.FirstOrDefault()?.ErrorMessage;
        }
    }
}
