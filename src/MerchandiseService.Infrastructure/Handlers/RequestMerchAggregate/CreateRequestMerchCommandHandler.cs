using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregatesModel;
using MerchandiseService.Domain.ValueObjects;
using MerchandiseService.Infrastructure.Commands;

namespace MerchandiseService.Infrastructure.Handlers.RequestMerchAggregate
{
    public class CreateRequestMerchCommandHandler : IRequestHandler<CreateRequestMerchCommand, int>
    {
        private readonly IRequestMerchRepository _requestMerchRepository;

        public CreateRequestMerchCommandHandler(IRequestMerchRepository requestMerchRepository)
        {
            _requestMerchRepository = requestMerchRepository;
        }
        
        public async Task<int> Handle(CreateRequestMerchCommand request, CancellationToken cancellationToken)
        {
            var requestInDb = await _requestMerchRepository.FindBySkuAsync(new Sku(request.Sku), cancellationToken);
            if (requestInDb is not null)
                throw new Exception($"Request merch item with sku {request.Sku} already exist");
            
            var newRequestMerch = new RequestMerch(
                new Sku(request.Sku),
                new MerchPack(MerchPackType.From(request.MerchPackType)),
                new Employee(request.EmployeeSku),
                new Date(request.RequestDateTime),
                new Quantity(request.Quantity), 
                Status.From(request.Status)
            );

            var createResult = await _requestMerchRepository.CreateAsync(newRequestMerch, cancellationToken);
            await _requestMerchRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            
            return newRequestMerch.Id;
        }
    }
}