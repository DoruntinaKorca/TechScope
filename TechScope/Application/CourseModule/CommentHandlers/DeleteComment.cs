using Application.Core;
using AutoMapper;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CourseModule.CommentHandlers
{
    public class DeleteComment
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid CommentId { get; set; }
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
                var comment = await _context.Comments.FindAsync(request.CommentId);

                if (comment == null) return null;

              

                _context.Remove(comment);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to delete comment");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
