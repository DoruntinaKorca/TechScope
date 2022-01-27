using Application.Core;
using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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

namespace Application.CourseModule.VideoHandlers
{
    public class VideoDetails
    {
        public class Query : IRequest<Result<VideoDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<VideoDto>>
        {
            private readonly TECHSCOPEContext _context;
            private readonly IMapper _mapper;

            public Handler(TECHSCOPEContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<VideoDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                //me kriju ni dto qe se shfaqe courseID/course
                var video = await _context.Videos
                    .Include(v=> v.Course)
                    .ProjectTo<VideoDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x=> x.VideoId == request.Id);

                return Result<VideoDto>.Success(video);
            }
        }
    }
}
