using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OMS74019FINALCSB.Data.Models
{
    public class Cart
    {

        [Key]
        public int CartId { get; set; }
        [ForeignKey("CustId")]
        public virtual int CustId { get; set; }
        public virtual Customer Customer { get; set; }
        [ForeignKey("ProductId")]
        public virtual int ProductId { get; set; }
        public virtual Products Products { get; set; }
        public int CartQuantity { get; set; }
        public int CartAmount { get; set; }
    }
}
