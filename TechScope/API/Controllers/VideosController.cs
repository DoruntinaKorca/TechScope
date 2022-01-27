using Application.CourseModule;
using Application.CourseModule.VideoHandlers;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class VideosController : BaseApiController
    {



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
            return HandleResult(await Mediator.Send(new CreateVideo.Command { Video = video, CourseId = id }));
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
