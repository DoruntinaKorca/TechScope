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

namespace Application.CourseHandlers.VideoHandlers
{
   public class EditVideo
    {
        public class Command : IRequest
        {
            public Video Video { get; set; }
            
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
                var video = await _context.Videos.FindAsync(request.Video.VideoId);


                _mapper.Map(request.Video, video);

              await _context.SaveChangesAsync();

                return Unit.Value;

            }
        }
    }
}
