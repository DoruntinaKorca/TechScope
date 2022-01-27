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
    public class DeleteTag
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid TagId { get; set; }

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
                var tag = await _context.AppTags.FindAsync(request.TagId);


                if (tag == null) return null;


                _context.Remove(tag);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to delete Tag");
                return Result<Unit>.Success(Unit.Value);

            }
        }
    }
}
