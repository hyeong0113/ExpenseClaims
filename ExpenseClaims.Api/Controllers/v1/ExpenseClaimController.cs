using ExpenseClaims.API.Controllers;
using ExpenseClaims.Application.Features.ExpenseClaims.Commands.Create;
using ExpenseClaims.Application.Features.ExpenseClaims.Commands.Delete;
using ExpenseClaims.Application.Features.ExpenseClaims.Commands.Update;
using ExpenseClaims.Application.Features.ExpenseClaims.Queries.GetAllPaged;
using ExpenseClaims.Application.Features.ExpenseClaims.Queries.GetById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Api.Controllers.v1
{
    public class ExpenseClaimController : BaseApiController<ExpenseClaimController>
    {
        [HttpGet(Name = "GetAllExpenseClaims")]
        public async Task<IActionResult> GetAll()
        {
            var claims = await _mediator.Send(new GetAllExpenseClaimsQuery());
            return Ok(claims);
        }

        [HttpGet("{id}", Name = "GetExpenseClaimById")]
        public async Task<IActionResult> GetById(int id)
        {
            var claim = await _mediator.Send(new GetExpenseClaimByIdQuery() { Id = id });
            return Ok(claim);
        }

        // POST api/<controller>
        [HttpPost(Name = "CreateExpenseClaim")]
        public async Task<IActionResult> Post(CreateExpenseClaimCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}", Name = "UpdateExpenseClaim")]
        public async Task<IActionResult> Put(int id, UpdateExpenseClaimCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}", Name = "DeleteExpenseClaim")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteExpenseClaimCommand { Id = id }));
        }
    }
}
