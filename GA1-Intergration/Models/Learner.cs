using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GA1_Intergration.Models
{
    public class Learner
    {
        [Key]
       
        public string Id { get; set; }
      [Display(Name = "Full Name: ")]
      public string first_Name { get; set; }
      [Display(Name = "Last Name: ")]
      public string last_Name { get; set; }
      [Display(Name = "Gender: ")]
      public string gender { get; set; }
      [Display(Name = "ID NO: ")]
      public string idNumber { get; set; }
      [Display(Name = "Home Language: ")]
      public string homeLanguage { get; set; }
      [Display(Name = "Home Address: ")]
      public string address { get; set; }
      [Display(Name = "City: ")]
      //public string city { get; set; }
      //[Display(Name = "Town: ")]
      public string town { get; set; }
      [Display(Name = "Postal Code: ")]
      public string postal { get; set; }
      [Display(Name = "Disability: ")]
      public string disabilities { get; set; }
    }
}