﻿using System;
using FlandersOpen.Application;
using FlandersOpen.Application.Referees;
using FlandersOpen.Read;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlandersOpen.Web.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/referee")]
    public class RefereeController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryService _queryService;

        public RefereeController(ICommandBus commandBus, IQueryService queryService)
        {
            _commandBus = commandBus;
            _queryService = queryService;
        }

        [HttpPost]
        public IActionResult Add([FromBody]AddRefereeCommand command)
        {
            if (!command.IsValid()) return FromValidation(command.ValidationMessages);

            var result = _commandBus.Dispatch(command);
            return FromResult(result);
        }

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var competitions = _queryService.Dispatch(new GetAllCompetitions());
        //    return Ok(competitions);
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetById(Guid id)
        //{
        //    var user = _queryService.Dispatch(new GetCompetitionById { Id = id });
        //    return Ok(user);
        //}

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody]UpdateRefereeCommand command)
        {
            command.Id = id;
            var result = _commandBus.Dispatch(command);
            return FromResult(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _commandBus.Dispatch(new RemoveRefereeCommand { Id = id });
            return FromResult(result);
        }
    }
}