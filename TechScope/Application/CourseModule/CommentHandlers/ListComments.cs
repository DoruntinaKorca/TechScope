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

namespace Application.CourseModule.CommentHandlers
{
   public class ListComments
    {
        public class Query : IRequest<Result<List<CommentDto>>>
        {
            public Guid CourseId { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<List<CommentDto>>>
        {
            private readonly TECHSCOPEContext _context;
            private readonly IMapper _mapper;

            public Handler(TECHSCOPEContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<CommentDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var comments = await _context.Comments
                     .Where(x => x.Course.CourseId == request.CourseId)
                     .OrderByDescending(x => x.DateCreated)
                     .ProjectTo<CommentDto>(_mapper.ConfigurationProvider)
                     .ToListAsync();



                return Result<List<CommentDto>>.Success(comments);

            }
        }
    }
}
