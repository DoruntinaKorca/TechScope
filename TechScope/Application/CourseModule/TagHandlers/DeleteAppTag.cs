using Application.Core;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CourseModule.TagHandlers
{
   public class DeleteAppTag
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid CourseId { get; set; }

            public string TagName { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly TECHSCOPEContext _context;

            public Handler(TECHSCOPEContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var appTag = await _context.AppTags.FindAsync(request.CourseId, request.TagName);


                if (appTag == null) return null;


                _context.Remove(appTag);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to delete App Tag");
                return Result<Unit>.Success(Unit.Value);

            }
        }
    }
}
