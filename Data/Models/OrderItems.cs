using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OMS74019FINALCSB.Data.Models
{
    public class OrderItems
    {
        [Key]
        public int OrderProductId { get; set; }
        [ForeignKey("OrderId")]
        public virtual int OrderId { get; set; }
        public virtual Orders Orders { get; set; }


        [ForeignKey("ProductId")]
        public virtual int ProductId { get; set; }

        public virtual Products Products { get; set; }

       
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }
        [StringLength(10)]
        [Column(TypeName = "varchar(10)")]
        public string OrderStatus { get; set; }


    }
}
