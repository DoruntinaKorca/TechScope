using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CommentDto
    {
        public string CommentId { get; set; }
        ///    public string CourseId { get; set; }
       // public string ReplyTo { get; set; }
        //  public string AuthorId { get; set; }
        public string CommentContent { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
