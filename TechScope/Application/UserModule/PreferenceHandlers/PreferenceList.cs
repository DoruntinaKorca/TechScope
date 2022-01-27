using Application.Core;
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

namespace Application.UserModule.PreferenceHandlers
{
    public class PreferenceList
    {
        public class Query : IRequest<Result<List<Preference>>>
        {

        }
        public class Handler : IRequestHandler<Query, Result<List<Preference>>>
        {
            private readonly TECHSCOPEContext _context;

            public Handler(TECHSCOPEContext context)
            {
                _context = context;
            }


            public async Task<Result<List<Preference>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var preferences = await _context.Preferences.ToListAsync();
                return Result<List<Preference>>.Success(preferences);
            }
        }
    }
}
