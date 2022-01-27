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

namespace Application.CourseModule.TagHandlers
{
    public class ListTag
    {
        public class Query : IRequest<Result<List<Tag>>>
        {
           
        }
        public class Handler : IRequestHandler<Query, Result<List<Tag>>>
        {
            private readonly TECHSCOPEContext _context;

            public Handler(TECHSCOPEContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Tag>>> Handle(Query request, CancellationToken cancellationToken)
            {

                var tags = await _context.Tags
                    .ToListAsync();

                return Result<List<Tag>>.Success(tags);
            }
        }
    }
}
