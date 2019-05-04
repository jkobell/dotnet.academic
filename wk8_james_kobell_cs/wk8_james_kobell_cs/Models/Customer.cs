using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wk8_james_kobell_cs.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set;}
        [Required]
        public string Fname { get; set;}
        [Required]
        public string Lname { get; set;}
        [Required]
        public string Address { get; set;}
        [Required]
        public string City { get; set;}
        [Required]
        public string State { get; set;}
        [Required]
        public int Zipcode { get; set;}
        
        //[ForeignKey("CustomerRefID")]
        //public ICollection<Cart> Carts { get; set; }
    }
}