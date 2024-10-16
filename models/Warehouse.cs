using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace DBase.Models
{
    public class Warehouse
    {
        [Key]
        public Guid ID_Warehouse { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(150)]
        public string? WarehouseName { get; set; }
        [Required]
        [MaxLength(400)]
        public string? Location { get; set; }
        [Required]
        [MaxLength(80)]
        public string? ManagerName { get; set; }
        public int Capacity { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Auto { get; set; }

        public virtual ICollection<Product>? Products { get; set; } // Navigation property
    }
}
