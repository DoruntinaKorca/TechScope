using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserPreference
    {
       // [Required]
       // public string PreferenceId { get; set; }
      //  [Required]

  

      // [Required]
      

        public Preference Preference { get; set; }


      //  [Required]
      //  public string UserId { get; set; }
        public User User { get; set; }
    }
}
