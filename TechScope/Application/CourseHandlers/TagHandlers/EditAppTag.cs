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

namespace Application.CourseHandlers.TagHandlers
{
   public class EditAppTag
    {
        public class Command : IRequest
        {
            public AppTag AppTag { get; set; }
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
                var appTag = await _context.AppTags.FindAsync(request.AppTag.Course, request.AppTag.TagName);

                _mapper.Map(request.AppTag, appTag);

            await _context.SaveChangesAsync();

               return Unit.Value;
            }
        }
    }
}
