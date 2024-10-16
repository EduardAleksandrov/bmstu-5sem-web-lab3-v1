using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace DBase.Models
{
    public class Supplier
    {
        [Key]
        public Guid ID_Supplier { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(150)]
        public string? SupplierName { get; set; }
        [MaxLength(150)]
        public string? ContactName { get; set; }
        [MaxLength(50)]
        public string? Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Phone { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Auto { get; set; }

        public virtual ICollection<Product>? Products { get; set; } // Navigation property
    }
}