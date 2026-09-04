namespace Rentaly.BusinessLayer.Constants
{
    public class ErrorMessages
    {
        public const string CustomerNameRequired = "Müşteri adı boş bırakılamaz.";
        public const string CustomerSurnameRequired = "Müşteri soyadı boş bırakılamaz.";
        public const string InvalidEmail = "Geçerli bir email adresi giriniz.";
        public const string InvalidPhone = "Telefon numarası geçersiz.";
        public const string IdentityNumberInvalid = "Kimlik numarası 11 haneli olmalıdır.";
        public const string DrivingLicenseRequired = "Ehliyet numarası boş bırakılamaz.";
        public const string DrivingLicenseDateInvalid = "Ehliyet tarihi gelecekte olamaz.";
        public const string BranchNameRequired = "Şube adı boş geçilemez.";
        public const string BranchNameLength = "Şube adı 2-100 karakter arasında olmalıdır.";
        public const string BranchAddressRequired = "Adres boş geçilemez.";
        public const string BranchAddressLength = "Adres 10-200 karakter arasında olmalıdır.";
        public const string BranchCityRequired = "Şehir boş geçilemez.";
        public const string BranchCityLength = "Şehir adı 2-100 karakter arasında olmalıdır.";
        public const string CategoryNameRequired = "Kategori adı boş geçilemez.";
        public const string CategoryNameLength = "Kategori adı 2-50 karakter arasında olmalıdır.";
        public const string CarModelNameRequired = "Model adı boş geçilemez.";
        public const string CarModelNameLength = "Model adı 2-60 karakter arasında olmalıdır.";
        public const string CarModelBrandRequired = "Marka seçilmelidir.";
    }
}
