using System.ComponentModel.DataAnnotations;

namespace Rentaly.EntityLayer.Enums
{
    public enum TransmissionType
    {
        [Display(Name = "Manuel")] Manual = 1,
        [Display(Name = "Otomatik")] Automatic = 2,
        [Display(Name = "Yarı Otomatik")] SemiAutomatic = 3
    }
}