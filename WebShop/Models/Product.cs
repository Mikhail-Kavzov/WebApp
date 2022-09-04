using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    [Serializable]
    public class Product
    {
        public int ProductId { get; set; }

        [StringLength(30, MinimumLength = 1, ErrorMessage = "Диапазон имени должен лежать в пределах от 1 до 30 символов")]
        public string? Name { get; set; }  //product name

        public CategoryType Category { get; set; } //product category

        [Range(1, 99999, ErrorMessage = "Цена должна лежать в пределах от 1 до 99999")]
        public decimal Price { get; set; }

        public AvailabilityType Availability { get; set; }  //InStock or None

        [StringLength(300, MinimumLength = 1, ErrorMessage = "Диапазон описания должен лежать в пределах от 1 до 30 символов")]
        public string? Description { get; set; }

        [Range(1, 9999, ErrorMessage = "Количество должно лежать в пределах от 1 до 9999")]
        public int Count { get; set; }

        public List<FileDB> FileProducts { get; set; } = new();


    }
}
