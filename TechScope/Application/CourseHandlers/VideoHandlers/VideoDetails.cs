using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CourseHandlers.VideoHandlers
{
    public class VideoDetails
    {
        public class Query : IRequest<Video>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Video>
        {
            private readonly TECHSCOPEContext _context;

            public Handler(TECHSCOPEContext context)
            {
                _context = context;
            }

            public async Task<Video> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Videos.FindAsync(request.Id);
            }
        }
    }
}
