﻿using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CourseHandlers.TagHandlers
{
   public class CreateAppTag
    {
        public class Command : IRequest
        {
            public AppTag AppTag { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly TECHSCOPEContext _context;

            public Handler(TECHSCOPEContext context)
            {
               _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.AppTags.Add(request.AppTag);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
