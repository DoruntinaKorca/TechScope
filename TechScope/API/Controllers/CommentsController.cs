using Application.CourseModule.CommentHandlers;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class CommentsController : BaseApiController
    {

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComments(Guid id)
        {
            return HandleResult(await Mediator.Send(new ListComments.Query { CourseId = id }));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CreateComment(Guid id, Comment comment)
        {
            return HandleResult(await Mediator.Send(new CreateComment.Command { CourseId = id, Comment = comment }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteComment.Command { CommentId = id }));
        }
    }
}
