using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace DBase.Models
{
    public class Order
    {
        [Key]
        public Guid ID_Order { get; set; } = Guid.NewGuid();
        [Required]
        public Guid CustomerID { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        [MaxLength(100)]
        public string? Status { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Auto { get; set; }

        public virtual Customer? Customer { get; set; } // Navigation property
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; } // Navigation property
    }
}
