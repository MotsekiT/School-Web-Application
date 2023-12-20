using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GA1_Intergration.Models
{
    public class Schools
    {
        [Key]
        [Required]
        public string Id { get; set; }
        [Display(Name = "Name of current school: ")]
        public string currentSchool { get; set; }

        [Required]
        [Display(Name = "Current grade: ")]
        public string currentGrade { get; set; }

        [Required]
        [Display(Name = "Language of instruction: ")]
        public string Language { get; set; }

        [Required]
        [Display(Name = "District: ")]
        public string District { get; set; }

        

        [Required]
        [Display(Name = "Name of applied school 1: ")]
        public string currentSchool_1 { get; set; }

        [Required]
        [Display(Name = "Grade applying for: ")]
        public string currentGrade_1 { get; set; }

        [Required]
        [Display(Name = "District: ")]
        public string District_1 { get; set; }


        [Display(Name = "Status")]
        public string Status { get; set; }



        [Required]
        [Display(Name = "Name of applied school 2: ")]
        public string currentSchool_2 { get; set; }

        [Required]
        [Display(Name = "Grade applying for: ")]
        public string currentGrade_2 { get; set; }

        [Required]
        [Display(Name = "District: ")]
        public string District_2 { get; set; }


        [Required]
        [Display(Name = "Name of applied school 3: ")]
        public string currentSchool_3 { get; set; }

        [Required]
        [Display(Name = "Grade applying for: ")]
        public string currentGrade_3 { get; set; }

        [Required]
        [Display(Name = "District: ")]
        public string District_3 { get; set; }

    }
}