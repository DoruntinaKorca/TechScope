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

namespace Application.CourseHandlers.VideoHandlers
{
    public class VideoList
    {
        public class Query : IRequest<List<Video>>
        {

        }
        public class Handler : IRequestHandler<Query, List<Video>>
        {
            private readonly TECHSCOPEContext _context;

            public Handler(TECHSCOPEContext context)
            {
                _context = context;
            }

            public async Task<List<Video>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Videos.ToListAsync();
            }
        }
    }
}
