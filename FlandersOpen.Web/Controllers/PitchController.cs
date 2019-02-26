using System;
using FlandersOpen.Application;
using FlandersOpen.Application.Pitches;
using FlandersOpen.Read;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlandersOpen.Web.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/competition")]
    public class PitchController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryService _queryService;

        public PitchController(ICommandBus commandBus, IQueryService queryService)
        {
            _commandBus = commandBus;
            _queryService = queryService;
        }

        [HttpPost]
        public IActionResult Add([FromBody]AddPitchCommand command)
        {
            if (!command.IsValid()) return FromValidation(command.ValidationMessages);

            var result = _commandBus.Dispatch(command);
            return FromResult(result);
        }

        [HttpPost]
        [Route("{id}/addtimeslots")]
        public IActionResult AddTimeslots(Guid id, [FromBody]AddTimeslotsToPitchCommand command)
        {
            command.Id = id;
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
        public IActionResult Update(Guid id, [FromBody]UpdatePitchCommand command)
        {
            command.Id = id;
            var result = _commandBus.Dispatch(command);
            return FromResult(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _commandBus.Dispatch(new RemovePitchCommand { Id = id });
            return FromResult(result);
        }

    }
}
