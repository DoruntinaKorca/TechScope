using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CourseModule
{
    public class CourseList
    {
        public class Query : IRequest<Result<List<Course>>>
        {

        }
        public class Handler : IRequestHandler<Query, Result<List<Course>>>
        {
            private readonly TECHSCOPEContext _context;

            public Handler(TECHSCOPEContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Course>>> Handle(Query request, CancellationToken cancellationToken)
            {

                var courses = await _context.Courses
                    .Include(v => v.Videos)
                    .Include(c=> c.Comments)
                    .ToListAsync(cancellationToken);
                return Result<List<Course>>.Success(courses);
            }
        }
    }
}
