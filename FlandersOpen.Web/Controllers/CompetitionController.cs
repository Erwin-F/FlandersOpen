﻿using FlandersOpen.Application;
using FlandersOpen.Application.Competitions;
using FlandersOpen.Read;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlandersOpen.Web.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/competition")]
    public class CompetitionController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryService _queryService;

        public CompetitionController(ICommandBus commandBus, IQueryService queryService)
        {
            _commandBus = commandBus;
            _queryService = queryService;
        }

        [HttpPost]
        public IActionResult Register([FromBody]CreateCompetitionCommand command)
        {
            if (!command.IsValid()) return FromValidation(command.ValidationMessages);
            
            var result = _commandBus.Dispatch(command);
            return FromResult(result);
        }

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var users = _queryService.Dispatch(new GetAllUsers());
        //    return Ok(users);
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var user = _queryService.Dispatch(new GetUserById { Id = id });
        //    return Ok(user);
        //}

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, [FromBody]UpdateUserCommand command)
        //{
        //    command.Id = id;
        //    var result = _commandBus.Dispatch(command);
        //    return FromResult(result);
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var result = _commandBus.Dispatch(new DeleteUserCommand { Id = id });
        //    return FromResult(result);
        //}

    }
}