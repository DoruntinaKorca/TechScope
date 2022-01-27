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
    public class CourseDetails
    {
        public class Query : IRequest<Result<Course>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<Course>>
        {
            private readonly TECHSCOPEContext _context;

            public Handler(TECHSCOPEContext context)
            {
                _context = context;
            }

            public async Task<Result<Course>> Handle(Query request, CancellationToken cancellationToken)
            {
               
                var course = await _context.Courses
                    .Include(v=>v.Videos)
                    .Include(c => c.Comments)
                    .FirstOrDefaultAsync(x=>x.CourseId == request.Id);

                return Result<Course>.Success(course);
            }
        }

    }
}
