using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
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
    public class CreateComment
    {
        public class Command : IRequest<Result<CommentDto>>
        {
            public Comment Comment { get; set; }
            public Guid CourseId { get; set; }
        }


        public class Handler : IRequestHandler<Command, Result<CommentDto>>
        {
            private readonly TECHSCOPEContext _context;
            private readonly IMapper _mapper;
            private readonly IUsernameAccessor _usernameAccessor;

            public Handler(TECHSCOPEContext context, IMapper mapper, IUsernameAccessor usernameAccessor)
            {
                _context = context;
                _mapper = mapper;
                _usernameAccessor = usernameAccessor;
            }

            public async Task<Result<CommentDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var course = await _context.Courses.FindAsync(request.CourseId);

                if (course == null) return null;

                var user = await _context.Users
                    .SingleOrDefaultAsync(x => x.UserName == _usernameAccessor.GetUsername());

                var comment = new Comment
                {
                    CommentContent = request.Comment.CommentContent,
                    DateCreated = request.Comment.DateCreated,
                    Course = course,
                    Author = user
                };

                course.Comments.Add(comment);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Result<CommentDto>.Success(_mapper.Map<CommentDto>(comment));

                return Result<CommentDto>.Failure("Failed to add comment");
            }
        }
    }
}
