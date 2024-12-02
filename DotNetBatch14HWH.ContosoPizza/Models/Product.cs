using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ContosoPizza.Models
{
    public class Product
    {
        public int Id { get; set; }

        // 1. required field [Required] public string Name { get; set; } OR
        public string Name { get; set; } = null;

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

    }
}
