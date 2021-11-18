using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregatesModel;
using MerchandiseService.Domain.ValueObjects;
using MerchandiseService.Infrastructure.Models;
using MerchandiseService.Infrastructure.Queries;
using MerchandiseService.Infrastructure.Queries.Responses;

namespace MerchandiseService.Infrastructure.Handlers.RequestMerchAggregate
{
    public class GetInfoAboutRequestMerchQueryHandler : IRequestHandler<GetInfoAboutRequestMerchQuery, GetInfoAboutRequestMerchResponse>
    {
        private readonly IRequestMerchRepository _requestMerchRepository;

        public GetInfoAboutRequestMerchQueryHandler(IRequestMerchRepository requestMerchRepository)
        {
            _requestMerchRepository = requestMerchRepository;
        }
        public async Task<GetInfoAboutRequestMerchResponse> Handle(GetInfoAboutRequestMerchQuery request, CancellationToken cancellationToken)
        {
            
            var result = await _requestMerchRepository.FindByEmployeeSkuAsync(new Sku(request.Sku), cancellationToken);
            return new GetInfoAboutRequestMerchResponse
            {
                Items = result.Select(x => new RequestMerchDto
                {
                    Sku = x.Sku.Value,
                    Quantity = x.Quantity.Value,
                    Status = x.Status.Id,
                    MerchPackType = x.MerchPackType.Id,
                    RequestDateTime = x.RequestDateTime
                }).ToList()
            };
        }
    }
}