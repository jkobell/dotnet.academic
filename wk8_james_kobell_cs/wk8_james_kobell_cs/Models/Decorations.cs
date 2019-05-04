using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace wk8_james_kobell_cs.Models
{
    public class Decorations
    {
        [Key]
        public string ProductID { get; set;}
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}