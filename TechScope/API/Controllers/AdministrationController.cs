using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AdministrationController : ControllerBase
    {
        private readonly TECHSCOPEContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdministrationController(TECHSCOPEContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<ActionResult<IdentityRole>> CreateRole(IdentityRole identityRole)
        {
            IdentityRole userRole = new IdentityRole
            {
                Name = identityRole.Name
            };
            await _roleManager.CreateAsync(userRole);

            return Ok(await _context.SaveChangesAsync());

        }

        /*
        [HttpGet]
        public async Task<ActionResult<List<IdentityRole>>> GetRoles()
        {
            if(_roleManager.Roles == null)
            {
                return NotFound(); 
            }
            var roles =  _roleManager.Roles;

            return Ok(roles);
        } 
        */
    }
}
