using AutoMapper;
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
    public class EditCourse
    {
        public class Command : IRequest
        {
            public Course Course { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly TECHSCOPEContext _context;
            private readonly IMapper _mapper;

            public Handler(TECHSCOPEContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var course = await _context.Courses.FindAsync(request.Course.CourseId);

                _mapper.Map(request.Course, course);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
