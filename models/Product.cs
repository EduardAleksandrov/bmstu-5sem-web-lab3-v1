using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace DBase.Models
{
    public class Product
    {
        [Key]
        public Guid ID_Product { get; set; } = Guid.NewGuid();
        [Required]
        public Guid SupplierID { get; set; }
        [Required]
        public Guid WarehouseID { get; set; }
        [Required]
        [MaxLength(800)]
        public string? ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int QuantityInStock { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Auto { get; set; }

        public virtual Supplier? Supplier { get; set; } // Navigation property
        public virtual Warehouse? Warehouse { get; set; } // Navigation property
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; } // Navigation property
    }
}
