using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GA1_Intergration.Models
{
    public class FileUpload
    {
        [Key]
        
        [Display(Name = "Parent ID")]
        [Required(ErrorMessage = "Parent ID is required")]
        public string ParentID { get; set; }



        [Display(Name = "Proof of Address")]
        [Required(ErrorMessage = "Proof of Address is required")]
        public string Address { get; set; }

        [Display(Name = "Additional Documents")]
        [Required(ErrorMessage = "Proof of Address is required")]
        public string Documents { get; set; }

        [Display(Name = "Learner ID")]
        [Required(ErrorMessage = "Proof of Address is required")]
        public string LearnerID { get; set; }

        [Display(Name = "Latest Grade Report")]
        [Required(ErrorMessage = "Proof of Address is required")]
        public string Report { get; set; }

        [Display(Name = "Disability Document")]
        [Required(ErrorMessage = "Proof of Address is required")]
        public string Disability { get; set; }




    }
}