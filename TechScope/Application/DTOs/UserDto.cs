using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
  public class UserDto
    {
        //the information we want to send back
        //to the user after they've logged in
        public string Id { get; set; }
        public string Token { get; set; }

        public string UserName { get; set; }
    }
}
