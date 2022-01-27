using Application.CourseModule.TagHandlers;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AppTagsController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppTags(Guid id)
        {
            var appTag = await Mediator.Send(new AppTagList.Query { CourseId = id });

            return HandleResult(appTag);
        }


        [HttpPost("{id}")]
        public async Task<IActionResult> CreateAppTag(Guid id, AppTag appTag)
        {

            return HandleResult(await Mediator.Send(new CreateAppTag.Command { AppTag = appTag, CourseId = id }));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppTag(Guid id, string tagName)
        {
            return HandleResult(await Mediator.Send(new DeleteAppTag.Command { TagName = tagName, CourseId = id }));
        }
    }
}
