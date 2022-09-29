using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI6.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Display(Name = "FIRST-NAME-LABEL", Prompt = "FIRST-NAME-PLACEHOLDER")]
        [Required(ErrorMessage ="REQUIRED-ERROR-MESSAGE")]
        public string first_name { get; set; }

        [Display(Name = "LAST-NAME-LABEL", Prompt = "LAST-NAME-PLACEHOLDER")]
        [Required(ErrorMessage ="REQUIRED-ERROR-MESSAGE")]
        public string last_name { get; set; }

        [Display(Name = "USER-NAME-LABEL", Prompt = "USER-NAME-PLACEHOLDER")]
        [Required(ErrorMessage = "REQUIRED-ERROR-MESSAGE")]
        public string username { get; set; }

        [Display(Name = "EMAIL-LABEL", Prompt = "EMAIL-PLACEHOLDER")]
        [EmailAddress]
        [Required(ErrorMessage = "REQUIRED-ERROR-MESSAGE")]
        public string email { get; set; }

        [Display(Name = "PASSWORD-LABEL", Prompt = "PASSWORD-PLACEHOLDER")]
        [DataType("Password")]
        [Required(ErrorMessage = "REQUIRED-ERROR-MESSAGE")]
        public string password { get; set; }

        [Display(Name = "COMPARE-PASSWORD-LABEL", Prompt = "CONFIRM-PASSWORD-PLACEHOLDER")]
        [DataType("Password")]
        [Required(ErrorMessage = "REQUIRED-ERROR-MESSAGE")]
        [Compare("password")]
        public string ComparePassword { get; set; }

        [Display(Name ="COUNTRY-LABEL", Prompt = "COUNTRY-PLACEHOLDER")]
        [Required(ErrorMessage ="REQUIRED-ERROR-MESSAGE")]
        public string country {  get; set; }

    }
}