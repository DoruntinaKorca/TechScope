using Application.CourseModule.TagHandlers;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class TagsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetTags()
        {
            var tag = await Mediator.Send(new ListTag.Query());

            return HandleResult(tag);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(Tag tag)
        {
            var tagg = await Mediator.Send(new CreateTag.Command { Tag = tag });
            return HandleResult(tagg); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteTag.Command { TagId = id }));
        }
    }
}
