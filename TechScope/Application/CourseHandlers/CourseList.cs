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

namespace Application.CourseHandlers
{
    public class CourseList
    {
        public class Query : IRequest<List<Course>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Course>>
        {
            private readonly TECHSCOPEContext _context;

            public Handler(TECHSCOPEContext context)
            {
                _context = context;
            }

            public async Task<List<Course>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Courses.ToListAsync();
            }

        }
    }
}
