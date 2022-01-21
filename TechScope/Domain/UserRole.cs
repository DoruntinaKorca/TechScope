using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserRole
    {
        public Guid UserRoleId { get; set; }
        public string UserRoleDescription { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
