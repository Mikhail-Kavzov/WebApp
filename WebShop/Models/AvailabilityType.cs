using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public enum AvailabilityType
    {
        [Display(Name = "In Stock")]
        InStock,

        [Display(Name = "None")]
        None
    }
}
