using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebShop.Models
{
    public enum CategoryType
    {
        [Display(Name = "Camera")]
        Camera,
        [Display(Name = "NoteBook")]
        Notebook,
        [Display(Name = "Smartphone")]
        Smartphone,
        [Display(Name = "Tablet")]
        Tablet
    }
}
