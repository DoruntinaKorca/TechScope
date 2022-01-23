using Application.CourseHandlers;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class CoursesController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetAllCourses()
        {
            return await Mediator.Send(new CourseList.Query());
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(Guid id)
        {
            return await Mediator.Send(new CourseDetails.Query { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(Course course)
        {
            return Ok(await Mediator.Send(new CreateCourse.Command { Course = course }));
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateCourse(Guid id, Course course)
        {
            course.CourseId = id;
            return Ok(await Mediator.Send(new EditCourse.Command { Course = course }));
        }



        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteCourse.Command { Id = id }));
        }

    }
}
