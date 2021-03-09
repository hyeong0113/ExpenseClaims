using AspNetCoreHero.Results;
using ExpenseClaims.API.Controllers;
using ExpenseClaims.Application.Features.ExpenseItems.Commands.Create;
using ExpenseClaims.Application.Features.ExpenseItems.Commands.Delete;
using ExpenseClaims.Application.Features.ExpenseItems.Commands.Update;
using ExpenseClaims.Application.Features.ExpenseItems.Queries.GetAll;
using ExpenseClaims.Application.Features.ExpenseItems.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseClaims.Api.Controllers.v1
{
    public class ExpenseItemController : BaseApiController<ExpenseItemController>
    {
        [HttpGet(Name = "GetAllExpenseItems")]
        public async Task<ActionResult<Result<IEnumerable<GetAllExpenseItemsResponse>>>> GetAll()
        {
            var items = await _mediator.Send(new GetAllExpenseItemsQuery());
            return Ok(items);
        }

        [HttpGet("{id}", Name = "GetExpenseItemById")]
        public async Task<ActionResult<Result<GetExpenseItemByIdResponse>>> GetById(int id)
        {
            var item = await _mediator.Send(new GetExpenseItemByIdQuery() { Id = id });
            return Ok(item);
        }

        // POST api/<controller>
        [HttpPost(Name = "CreateExpenseItem")]
        public async Task<ActionResult<Result<int>>> Post(CreateExpenseItemCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}", Name = "UpdateExpenseItem")]
        public async Task<ActionResult<Result<int>>> Put(int id, UpdateExpenseItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}", Name = "DeleteExpenseItem")]
        public async Task<ActionResult<Result<int>>> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteExpenseItemCommand { Id = id }));
        }
    }
}
