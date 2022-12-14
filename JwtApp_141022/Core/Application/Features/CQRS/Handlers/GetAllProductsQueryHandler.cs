using AutoMapper;
using JwtApp_141022.Core.Application.Dtos;
using JwtApp_141022.Core.Application.Features.CQRS.Queries;
using JwtApp_141022.Core.Application.Interfaces;
using JwtApp_141022.Core.Domain;
using MediatR;

namespace JwtApp_141022.Core.Application.Features.CQRS.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, List<ProductListDto>>
    {

        private readonly IRepository<Product> _repoProduct;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IRepository<Product> repoProduct, IMapper mapper)
        {
            _repoProduct = repoProduct;
            _mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repoProduct.GetAllAsync();
            return _mapper.Map<List<ProductListDto>>(data);
        }
    }
}
