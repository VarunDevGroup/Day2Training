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
        [Required]
        public string Name { get; set; }

        [Required]
        public string ProductInfo { get; set; }
      


    }
}
