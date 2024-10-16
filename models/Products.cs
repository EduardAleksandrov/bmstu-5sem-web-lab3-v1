using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBase.Models
{
    public class Products
    {
        [Key]
        public Guid Id_Product { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(350)] 
        public string? ProductName { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Auto { get; set; }
    }
}