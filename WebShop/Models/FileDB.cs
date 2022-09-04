namespace WebShop.Models
{
    public class FileDB
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Path { get; set; }

        public int ProductId { get; set; }
        
        public Product? Product { get; set; }
    }
}
