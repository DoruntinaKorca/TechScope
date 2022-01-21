using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CourseHandlers
{
    public class CourseDetails
    {
        public class Query : IRequest<Course>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Course>
        {
            private readonly TECHSCOPEContext _context;

            public Handler(TECHSCOPEContext context)
            {
                _context = context;
            }

            public async Task<Course> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Courses.FindAsync(request.Id);
            }
        }

    }
}
