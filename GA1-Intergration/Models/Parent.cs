using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GA1_Intergration.Models
{
    public class Parent
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [Display(Name = "Full Name: ")]
        public string firstName { get; set; }
        [Required]
        [Display(Name = "Last Name: ")]
        public string lastName { get; set; }
        [Required]

        [Display(Name = "ID NO: ")]
        public string IdNo { get; set; }
        [Required]

        [Display(Name = "Gender: ")]
        public string gender { get; set; }
        [Required]

        [Display(Name = "Contact No: ")]
        public string cellNo { get; set; }
        [Required]

        [Display(Name = "Address: ")]
        public string address { get; set; }
        [Required]

        [Display(Name = "City: ")]
        public string city { get; set; }
        [Required]

        [Display(Name = "Province: ")]
        public string province { get; set; }
        [Required]

        [Display(Name = "Postal Code: ")]
        public string postal { get; set; }
        [Required]

        [Display(Name = "Relationship Status: ")]
        public string relationship { get; set; }
        [Required]

        [Display(Name = "Employment Status: ")]
        public string employement { get; set; }
    }
}