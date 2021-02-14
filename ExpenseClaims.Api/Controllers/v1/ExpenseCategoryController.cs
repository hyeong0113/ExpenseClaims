using ExpenseClaims.API.Controllers;
using ExpenseClaims.Application.Features.ExpenseCategories.Commands.Create;
using ExpenseClaims.Application.Features.ExpenseCategories.Commands.Delete;
using ExpenseClaims.Application.Features.ExpenseCategories.Commands.Update;
using ExpenseClaims.Application.Features.ExpenseCategories.Quries.GetAll;
using ExpenseClaims.Application.Features.ExpenseCategories.Quries.GetById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Api.Controllers.v1
{
    public class ExpenseCategoryController : BaseApiController<ExpenseCategoryController>
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _mediator.Send(new GetAllExpenseCategoriesQuery());
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _mediator.Send(new GetExpenseCategoryByIdQuery() { Id = id });
            return Ok(item);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateExpenseCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateExpenseCategoryCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteExpenseCategoryCommand { Id = id }));
        }
    }
}
