using Application.DTOs;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Course, Course>();
            CreateMap<Video, Video>();
            CreateMap<AppTag, AppTag>();
         //   CreateMap<Course, CourseDto>();
            CreateMap<Video, VideoDto>();
            CreateMap<Comment, CommentDto>();
          
        }
    }
}
