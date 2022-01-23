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

namespace Application.CourseHandlers.TagHandlers
{
   public class AppTagList 
    {
        public class Query : IRequest<List<AppTag>>
        {

        }
        public class Handler : IRequestHandler<Query, List<AppTag>>
        {
            private readonly TECHSCOPEContext _context;

            public Handler(TECHSCOPEContext context)
            {
                _context = context;
            }

            public async Task<List<AppTag>> Handle(Query request, CancellationToken cancellationToken)
            {
               return await _context.AppTags.ToListAsync();
            }
        }
    }
}
