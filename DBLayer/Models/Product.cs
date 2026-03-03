using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBLayer.Models
{


    [Table("tblProduct")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(150)]
        public string? Name { get; set; }
        
    }
}
