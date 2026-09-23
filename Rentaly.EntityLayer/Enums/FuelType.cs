using System.ComponentModel.DataAnnotations;

namespace Rentaly.EntityLayer.Enums
{
    public enum FuelType
    {
        [Display(Name = "Benzin")] Petrol = 1,
        [Display(Name = "Dizel")] Diesel = 2,
        [Display(Name = "Elektrik")] Electric = 3,
        [Display(Name = "Hibrit")] Hybrid = 4,
        [Display(Name = "LPG")] LPG = 5
    }
}