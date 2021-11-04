using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregatesModel;
using MerchandiseService.Domain.ValueObjects;
using MerchandiseService.Infrastructure.Queries;

namespace MerchandiseService.Infrastructure.Handlers.RequestMerchAggregate
{
    public class GetInfoAboutRequestMerchQueryHandler : IRequestHandler<GetInfoAboutRequestMerchQuery, int>
    {
        private readonly IRequestMerchRepository _requestMerchRepository;

        public GetInfoAboutRequestMerchQueryHandler(IRequestMerchRepository requestMerchRepository)
        {
            _requestMerchRepository = requestMerchRepository;
        }
        public async Task<int> Handle(GetInfoAboutRequestMerchQuery request, CancellationToken cancellationToken)
        {
            var result = await _requestMerchRepository.FindBySkuAsync(new Sku(request.Sku));
            return 1;
        }
    }
}