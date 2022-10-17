using JwtApp_141022.Core.Application.Features.CQRS.Commands;
using JwtApp_141022.Core.Application.Features.CQRS.Queries;
using JwtApp_141022.Core.Domain;
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
    [Authorize(Roles = "Admin,Member")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllProductsQueryRequest());
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await _mediator.Send(new GetProductQueryRequest(Id));
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _mediator.Send(new DeleteProductCommantRequest(Id));
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductCommandRequest product)
        {
            await _mediator.Send(product);
            return Created("", "");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommamdRequest product)
        {
            await _mediator.Send(product);
            return NoContent();
        }
    }
}
