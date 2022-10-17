using AutoMapper;
using JwtApp_141022.Core.Application.Dtos;
using JwtApp_141022.Core.Application.Features.CQRS.Queries;
using JwtApp_141022.Core.Application.Interfaces;
using JwtApp_141022.Core.Domain;
using MediatR;

namespace JwtApp_141022.Core.Application.Features.CQRS.Handlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest, ProductListDto>
    {
        private readonly IRepository<Product> _repoProduct;
        private readonly IMapper _mapper;
        public GetProductQueryHandler(IRepository<Product> repoProduct, IMapper mapper)
        {
            _repoProduct = repoProduct;
            _mapper = mapper;
        }

        public async Task<ProductListDto> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repoProduct.GetByIdAsync(request.Id);

            var result = _mapper.Map<ProductListDto>(data);
            return result;
        }
    }
}
