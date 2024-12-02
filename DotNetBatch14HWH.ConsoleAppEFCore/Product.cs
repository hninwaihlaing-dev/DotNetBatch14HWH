using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ConsoleAppEFCore
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Column("Id")]
        public int Id {  get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Price", TypeName = "decimal(20,2)")]
        public double Price { get; set; }
        [Column("Quantity")]
        public int Quantity { get; set; }

    }
}
