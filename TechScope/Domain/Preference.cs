using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Preference
    {
        public Guid PreferenceId { get; set; }
        public string PreferenceName { get; set; }

        public ICollection<UserPreference> UserPreferences { get; set; } = new List<UserPreference>();
    }
}
