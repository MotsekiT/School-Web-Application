using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
/*
220000213 M Tshabalala
219014331 SL Hadebe
219007267 MP Tsoaela    
*/
namespace GA1_Intergration.Models
{
    public class SignUp
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Name and Surname")]
        public string Name { get; set; }


        [Required,Display(Name ="Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        

        [Required(ErrorMessage = "Passoword is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage ="Please confirm your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm " +
            "Password")]
        public string ConfirmPassword { get; set; }
        
       

    }
}