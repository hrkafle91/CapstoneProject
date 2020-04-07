using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBModel
{
	public class AccountMetadata
	{

        [Required(ErrorMessage = "Username is required.")]
        [Display(Name = "Username")]
        public string userName { get; set; }

        [StringLength(8, MinimumLength = 8, ErrorMessage = "Password should be exactly 8 characters long")]
        [Required(ErrorMessage = "Password is required.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [Display(Name = "Email Address")]
        public string emailID { get; set; }

        [Required(ErrorMessage = "User Type is required.")]
        [Display(Name = "Type")]
        public string userType { get; set; }
    }
}
