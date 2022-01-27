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
    public class VideoList
    {
        public class Query : IRequest<Result<List<VideoDto>>>
        {
            public Guid CourseId { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<List<VideoDto>>>
        {
            private readonly TECHSCOPEContext _context;
            private readonly IMapper _mapper;

            public Handler(TECHSCOPEContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<VideoDto>>> Handle(Query request, CancellationToken cancellationToken)
            {

                var videos = await _context.Videos
                    .Where(c=> c.Course.CourseId == request.CourseId)
                    .ProjectTo<VideoDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return Result<List<VideoDto>>.Success(videos);
            }
        }
    }
}
