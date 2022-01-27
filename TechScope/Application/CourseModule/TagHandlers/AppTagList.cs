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

namespace Application.CourseModule.TagHandlers
{
   public class AppTagList 
    {
        public class Query : IRequest<Result<List<AppTagDto>>>
        {
            public Guid CourseId { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<List<AppTagDto>>>
        {
            private readonly TECHSCOPEContext _context;
            private readonly IMapper _mapper;

            public Handler(TECHSCOPEContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<AppTagDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
              
                var appTags =  await _context.AppTags
                    .Where(x=>x.Course.CourseId == request.CourseId)
                     .ProjectTo<AppTagDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return Result<List<AppTagDto>>.Success(appTags);
            }
        }
    }
}
