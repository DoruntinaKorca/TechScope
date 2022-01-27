using Application.UserModule.PreferenceHandlers;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class PreferencesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetPreferences()
        {
            var preferences = await Mediator.Send(new PreferenceList.Query());
            return HandleResult(preferences);

        }

        [HttpPost]
        public async Task<IActionResult> CreatePreference(Preference preference)
        {
            var preferences = await Mediator.Send(new CreatePreference.Command { Preference = preference });
            return HandleResult(preferences);
        }
    }
}
