using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace wk8_james_kobell_cs.Models
{
    public class Categories
    {
        [Key]
        public string CategoryID { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        
    }
}