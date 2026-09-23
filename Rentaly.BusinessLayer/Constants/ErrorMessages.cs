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
        public const string CarPlateRequired = "Plaka boş geçilemez.";
        public const string CarVinRequired = "Şasi numarası boş geçilemez.";
        public const string CarVinLength = "Şasi numarası 17 karakter olmalıdır.";
        public const string CarModelRequired = "Model seçilmelidir.";
        public const string CarBranchRequired = "Şube seçilmelidir.";
        public const string CarYearInvalid = "Araç yılı geçerli bir değer olmalıdır.";
        public const string CarKilometerInvalid = "Kilometre negatif olamaz.";
        public const string CarDailyPriceInvalid = "Günlük fiyat 0'dan büyük olmalıdır.";
        public const string CarDepositInvalid = "Depozito negatif olamaz.";
        public const string CarImageRequired = "Araç görseli boş geçilemez.";
        public const string CarImageLength = "Görsel adresi en fazla 300 karakter olabilir.";
        public const string CarSeatCountInvalid = "Koltuk sayısı 1 ile 12 arasında olmalıdır.";
        public const string CarLuggageInvalid = "Bagaj sayısı negatif olamaz.";
        public const string CarFuelTypeInvalid = "Geçerli bir yakıt tipi seçilmelidir.";
        public const string CarTransmissionInvalid = "Geçerli bir vites tipi seçilmelidir.";
        public const string CarIdRequired = "Geçerli bir araç seçilmelidir.";
        public const string CarPlateFormat = "Plaka formatı geçersiz. Örnek: 34ABC12, 34AB123, 06A1234";
        public const string CarPlateAlreadyExists = "Bu plaka ile kayıtlı bir araç zaten var.";
        public const string CarVinFormat = "Şasi numarası geçersiz karakter içeriyor.";
        public const string CarVinAlreadyExists = "Bu şasi numarası ile kayıtlı bir araç zaten var.";
    }
}
