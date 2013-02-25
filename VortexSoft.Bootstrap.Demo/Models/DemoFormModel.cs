using System;
using System.ComponentModel.DataAnnotations;

namespace VortexSoft.Bootstrap.Demo.Models
{
    public class DemoFormModel
    {
        [Display(Name = "First Name", Order = 1)]
        [Required]
        [StringLength(128)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name", Order = 2)]
        [Required]
        [StringLength(128)]
        public string LastName { get; set; }

        [Display(Name = "Date Of Birth", Order = 4)]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Password)]
        [Display(Order = 3)]
        public string Password { get; set; }

        [Display(Name = "I like this!", Order = 5)]
        public bool Like { get; set; }

        public string Keywords { get; set; }
    }
}