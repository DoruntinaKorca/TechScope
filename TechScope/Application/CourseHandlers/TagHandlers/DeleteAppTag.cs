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
   public class DeleteAppTag
    {
        public class Command : IRequest
        {
            public Guid CourseId { get; set; }

            public string TagName { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly TECHSCOPEContext _context;

            public Handler(TECHSCOPEContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var appTag = await _context.AppTags.FindAsync(request.CourseId, request.TagName);

                _context.Remove(appTag);

                await _context.SaveChangesAsync();

                return Unit.Value;

            }
        }
    }
}
