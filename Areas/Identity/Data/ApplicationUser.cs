using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MultipleDesk.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [Required]
    [Column(TypeName = "nvarchar(100)")]
    [Display(Name ="First Name")]
    public string FirstName { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(100)")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }


    [Required]
    [Display(Name ="Phone Number")]
    public long PhoneNumber { get; set; }

}

