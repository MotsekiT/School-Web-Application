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
    public class Login
    {
      [Key]
      public int Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]

        public string Password { get; set; }

        public bool IsAdmin{ get; set; }
      
    }
}