using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DBase.Models
{
    public class OrderDetail
    {
        [Key]
        public Guid ID_OrderDetails { get; set; } = Guid.NewGuid();
        [Required]
        public Guid OrderId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Auto { get; set; }
        
        [JsonIgnore]
        public virtual Order? Order { get; set; } // Navigation property
        public virtual Product? Product { get; set; } // Navigation property
    }

}
