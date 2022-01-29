using Application.CourseModule;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await Mediator.Send(new CourseList.Query());
            return HandleResult(courses);
        }

      //  [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(Guid id)
        {
            var result = await Mediator.Send(new CourseDetails.Query { Id = id });
            return HandleResult(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CreateCourse(Course course, string id)
        {
            return HandleResult(await Mediator.Send(new CreateCourse.Command { Course = course, Id = id }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(Guid id, Course course)
        {
            course.CourseId = id;
            return HandleResult(await Mediator.Send(new EditCourse.Command { Course = course }));
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteCourse.Command { Id = id }));
        }

    }
}
