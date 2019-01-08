using FlandersOpen.Application;
using FlandersOpen.Application.Services;
using FlandersOpen.Application.Users;
using FlandersOpen.Read;
using FlandersOpen.Read.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlandersOpen.Web.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/user")]
    public class UserController : BaseController
    {
        private readonly IAuthenticationService _authService;
        private readonly ICommandBus _commandBus;
        private readonly IQueryService _queryService;

        public UserController(IAuthenticationService authService, ICommandBus commandBus, IQueryService queryService)
        {
            _authService = authService;
            _commandBus = commandBus;
            _queryService = queryService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserCredentials credentials)
        {
            var authenticatedUser = _authService.GetToken(credentials);

            return authenticatedUser == null ? Unauthorized() : Ok(authenticatedUser);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterUserCommand command)
        {
            if (!command.IsValid()) return FromValidation(command.ValidationMessages);
            
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
            if (!command.IsValid()) return FromValidation(command.ValidationMessages);
            
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