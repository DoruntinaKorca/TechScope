using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AppTag
    {
    //   [Required]
       //public string CourseId { get; set; }
       [MaxLength(50)]
        public string TagName { get; set; }
      //  [Required]
        public  Course Course { get; set; }
    }
}

