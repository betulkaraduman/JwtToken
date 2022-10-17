using JwtApp_141022.Core.Application.Dtos;
using MediatR;

namespace JwtApp_141022.Core.Application.Features.CQRS.Commands
{
    public class DeleteProductCommantRequest:IRequest
    {
        public int Id { get; set; }
        public DeleteProductCommantRequest(int id)
        {
            Id = id;
        }
    }
}
