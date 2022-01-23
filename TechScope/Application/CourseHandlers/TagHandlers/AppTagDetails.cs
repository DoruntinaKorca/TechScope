using Domain;
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
   public class AppTagDetails
    {
        public class Query : IRequest<AppTag>
        {
            public Guid CourseId { get; set; }

            public string TagName { get; set; }
        }
        public class Handler : IRequestHandler<Query, AppTag>
        {
            private readonly TECHSCOPEContext _context;
            
            public Handler(TECHSCOPEContext context)
            {
               _context = context;
            }

            public async Task<AppTag> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.AppTags.FindAsync(request.TagName,request.CourseId);
            }
        }
    }
}
