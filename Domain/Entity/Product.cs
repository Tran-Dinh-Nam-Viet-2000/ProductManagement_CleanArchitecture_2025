using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
    }
}
