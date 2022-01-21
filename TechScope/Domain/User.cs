using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User : IdentityUser
    {


        //     public string UserName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        //  public string UserEmail { get; set; }
        //  public string UserPassword { get; set; }
        public DateTime UserDob { get; set; }


        public ICollection<Course> Courses { get; set; }

        [Required]
      //  public string UserRoleId { get; set; }
        public UserRole UserRolee { get; set; }
        //  public ICollection<Comment> Comments { get; set; }
       public ICollection<UserPreference> UserPreferences { get; set; }


    }
}
