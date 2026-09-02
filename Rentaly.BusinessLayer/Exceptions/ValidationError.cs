namespace Rentaly.BusinessLayer.Exceptions
{
    public record ValidationError(string PropertyName, string ErrorMessage);
}