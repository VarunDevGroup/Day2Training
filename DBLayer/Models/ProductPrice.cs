using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBLayer.Models
{
    public class ProductPrice
    {
       [Key]
        public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }

         
        public string? ProductRemarks { get; set; }
    }
}
