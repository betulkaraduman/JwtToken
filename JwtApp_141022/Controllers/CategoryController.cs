using JwtApp_141022.Core.Application.Features.CQRS.Commands;
using JwtApp_141022.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtApp_141022.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetALl()
        {
            var result = await _mediator.Send(new GetAllCategoryQueryRequest());
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await _mediator.Send(new GetCategoryQueryRequest(Id));
            return Ok(result);

        }
        [HttpPost]
        public async Task<IActionResult>  Add(AddCategoryCommandRequest category)
        {
            await _mediator.Send(category);
            return Created("", "");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommandRequest category)
        {
            await _mediator.Send(category);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _mediator.Send(new DeleteCategoryCommandRequest(Id));
            return NoContent(); 
        }


    }
}
