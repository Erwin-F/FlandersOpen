using FlandersOpen.Read;
using FlandersOpen.Read.Teams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlandersOpen.Web.Controllers
{
    [Authorize]
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
