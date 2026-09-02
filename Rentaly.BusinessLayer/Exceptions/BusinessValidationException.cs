namespace Rentaly.BusinessLayer.Exceptions
{
    public class BusinessValidationException : Exception
    {
        public IReadOnlyList<ValidationError> Errors { get; }

        public BusinessValidationException(IReadOnlyList<ValidationError> errors)
            : base("Doğrulama hatası.")
        {
            Errors = errors;
        }
    }
}