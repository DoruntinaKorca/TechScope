using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Course
    {
        
        public Guid CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public DateTime DateUploaded { get; set; }
        public DateTime DateModified { get; set; }
        public int? CourseViews { get; set; }
        public int? CourseRating { get; set; }

        public int? CourseApprovedBy { get; set; }

        //[Required]
        // public string UserId { get; set; }
        [Required]
        public User User { get; set; }

        public ICollection<AppTag> AppTags { get; set; }

       public ICollection<Video> Videos { get; set; }

      //  public ICollection<Comment> Comments { get; set; }


    }
}
