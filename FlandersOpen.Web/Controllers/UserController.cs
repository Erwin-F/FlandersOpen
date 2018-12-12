using FlandersOpen.Command;
using FlandersOpen.Command.Users;
using FlandersOpen.Infrastructure;
using FlandersOpen.Read;
using FlandersOpen.Web.Helpers;
using FlandersOpen.Read.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FlandersOpen.Web.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/user")]
    public class UserController : BaseController
    {
        private readonly AppSettings _appSettings;
        private readonly CommandBus _commandBus;
        private readonly QueryService _queryService;

        public UserController(IOptions<AppSettings> appSettings, CommandBus commandBus, QueryService queryService)
        {
            _appSettings = appSettings.Value;
            _commandBus = commandBus;
            _queryService = queryService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]GetAuthenticatedUser query)
        {
            var authUser = _queryService.Dispatch(query);

            if (authUser == null) return Unauthorized();

            authUser.Token = SecurityHelper.GetToken(_appSettings.Secret, authUser.Id);

            return Ok(authUser);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterUserCommand command)
        {
            var result = _commandBus.Dispatch(command);
            return FromResult(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _queryService.Dispatch(new GetAllUsers());
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _queryService.Dispatch(new GetUserById { Id = id });
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdateUserCommand command)
        {
            command.Id = id;
            var result = _commandBus.Dispatch(command);
            return FromResult(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _commandBus.Dispatch(new DeleteUserCommand{ Id = id });
            return FromResult(result);
        }
    }
}