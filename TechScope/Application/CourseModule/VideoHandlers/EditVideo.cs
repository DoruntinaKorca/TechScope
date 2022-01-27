using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CourseModule.VideoHandlers
{
   public class EditVideo
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Video Video { get; set; }
            
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Video).SetValidator(new VideoValidator());

            }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly TECHSCOPEContext _context;
            private readonly IMapper _mapper;

            public Handler(TECHSCOPEContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var video = await _context.Videos.FindAsync(request.Video.VideoId);


                _mapper.Map(request.Video, video);

                var result = await _context.SaveChangesAsync() > 0;
                _mapper.Map(request.Video, video);

                if (!result) return Result<Unit>.Failure("Failed to update the video");
                return Result<Unit>.Success(Unit.Value);

            }
        }
    }
}
