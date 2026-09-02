using FluentValidation;

namespace Rentaly.BusinessLayer.Exceptions
{
    public static class ValidatorExtensions
    {
        public static async Task ValidateOrThrowAsync<T>(this IValidator<T> validator, T instance)
        {
            var result = await validator.ValidateAsync(instance);

            if (result.IsValid)
                return;

            var errors = result.Errors
                .Select(x => new ValidationError(x.PropertyName, x.ErrorMessage))
                .ToList();

            throw new BusinessValidationException(errors);
        }
    }
}