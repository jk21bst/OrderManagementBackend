using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OMS74019FINALCSB.Data.Models
{
    public class Products
    {

        [Key]
        public int ProductId { get; set; }
        [Column(TypeName = "varchar(20)")]
        [StringLength(20)]
        public string ProductCategory { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductCost { get; set; }
       
        public string ProductUrl { get; set; }

    }
}
