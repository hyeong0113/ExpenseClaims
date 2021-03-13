using AspNetCoreHero.Results;
using ExpenseClaims.API.Controllers;
using ExpenseClaims.Application.Features.Currencies.Commands.Create;
using ExpenseClaims.Application.Features.Currencies.Commands.Delete;
using ExpenseClaims.Application.Features.Currencies.Commands.Update;
using ExpenseClaims.Application.Features.Currencies.Quries.GetAll;
using ExpenseClaims.Application.Features.Currencies.Quries.GetById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Api.Controllers.v1
{
    [Authorize(Roles = "SuperAdmin")]
    public class CurrencyController : BaseApiController<CurrencyController>
    {
        [HttpGet(Name = "GetAllCurrencies")]
        public async Task<ActionResult<Result<IEnumerable<GetAllCurrenciesResponse>>>> GetAll()
        {
            var items = await _mediator.Send(new GetAllCurrenciesQuery());
            return Ok(items);
        }

        [HttpGet("{id}", Name = "GetCurrencyById")]
        public async Task<ActionResult<Result<GetCurrencyByIdResponse>>> GetById(int id)
        {
            var item = await _mediator.Send(new GetCurrencyByIdQuery() { Id = id });
            return Ok(item);
        }

        // POST api/<controller>
        [HttpPost(Name = "CreateCurrency")]
        public async Task<ActionResult<Result<int>>> Post(CreateCurrencyCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}", Name = "UpdateCurrency")]
        public async Task<ActionResult<Result<int>>> Put(int id, UpdateCurrencyCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}", Name = "DeleteCurrency")]
        public async Task<ActionResult<Result<int>>> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteCurrencyCommand { Id = id }));
        }
    }
}
