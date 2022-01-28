using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Video
    {
        public Guid VideoId { get; set; }
        public string VideoTitle { get; set; }
        public string VideoDescription { get; set; }
        public int VideoLength { get; set; }

        //public IFormFile file { get; set; }

     // [Required]
        public Course Course { get; set; }
    }
}
