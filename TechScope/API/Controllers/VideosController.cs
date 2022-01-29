using Application.Core;
using Application.CourseModule;
using Application.CourseModule.VideoHandlers;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class VideosController : BaseApiController
    {
        private IHostingEnvironment _env;
        private IFormFile file;
        private static Video myvid;
        private static Guid Cid;
        private readonly TECHSCOPEContext _context;
        public VideosController(IHostingEnvironment env)
        {
            _env = env;
        }

        public class Command : IRequest<Result<Unit>>
        {
            public Course Course { get; set; }
            public string Id { get; set; }

        }


        [HttpGet("getAllVideos/{id}")]
        public async Task<ActionResult<List<Video>>> GetAllVideos(Guid id)
        {
            var videos =  await Mediator.Send(new VideoList.Query { CourseId = id});
            return HandleResult(videos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Video>> GetVideo(Guid id)
        {
           var video = await Mediator.Send(new VideoDetails.Query { Id = id });
            return HandleResult(video);
        }
        


        [HttpPost("{id}")]
        public async Task<IActionResult> CreateVideo(Video video, Guid id)
        {
            myvid = video;
            Cid = id;
            return HandleResult(await Mediator.Send(new CreateVideo.Command { Video = video, CourseId = id }));
        }



        [HttpPost("add")]
        public IActionResult CreateVideo(IFormFile file)
        {
            string vidid = myvid.VideoTitle.ToString();
            string id = Cid.ToString();
            var dir = _env.ContentRootPath;
            using (var fileStream = new FileStream(Path.Combine(dir, "Videos",id,vidid + ".mp4"), FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }
            return Ok("pobon");
        }

        [HttpPut("{id}")]
        public async Task <IActionResult> UpdateVideo(Video video, Guid id)
        {
            video.VideoId = id;
            return HandleResult(await Mediator.Send(new EditVideo.Command{ Video = video}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideo(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteVideo.Command { Id = id }));
        }
    }
}
