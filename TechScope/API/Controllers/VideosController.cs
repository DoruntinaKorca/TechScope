using Application.CourseHandlers;
using Application.CourseHandlers.VideoHandlers;
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



        [HttpGet]
        public async Task<ActionResult<List<Video>>> GetAllVideos()
        {
            return await Mediator.Send(new VideoList.Query());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Video>> GetVideo(Guid id)
        {
            return await Mediator.Send(new VideoDetails.Query { Id = id });

        }

        [HttpPost]
        public async Task<IActionResult> CreateVideo(Video video)
        {
            return Ok(await Mediator.Send(new CreateVideo.Command { Video = video }));
        }

        [HttpPut("{id}")]
        public async Task <IActionResult> UpdateVideo(Video video, Guid id)
        {
            video.VideoId = id;
            return Ok(await Mediator.Send(new EditVideo.Command{ Video = video}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideo(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteVideo.Command { Id = id }));
        }
    }
}
