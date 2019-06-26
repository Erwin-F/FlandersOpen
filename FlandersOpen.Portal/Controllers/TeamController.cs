using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlandersOpen.Read;
using FlandersOpen.Read.Teams;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlandersOpen.Portal.Controllers
{
    [Produces("application/json")]
    [Route("api/team")]
    public class TeamController : BaseController
    {
        private readonly IQueryService _queryService;

        public TeamController(IQueryService queryService)
        {
            _queryService = queryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var teams = _queryService.Dispatch(new GetAllTeams());
            return Ok(teams);
        }
    }
}
