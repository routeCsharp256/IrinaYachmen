using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregatesModel;
using MerchandiseService.Domain.Contracts;
using MerchandiseService.Domain.ValueObjects;
using MerchandiseService.Infrastructure.Commands;

namespace MerchandiseService.Infrastructure.Handlers.RequestMerchAggregate
{
    public class CreateRequestMerchCommandHandler : IRequestHandler<CreateRequestMerchCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRequestMerchRepository _requestMerchRepository;

        public CreateRequestMerchCommandHandler(IRequestMerchRepository requestMerchRepository, IUnitOfWork unitOfWork)
        {
            _requestMerchRepository = requestMerchRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<int> Handle(CreateRequestMerchCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.StartTransaction(cancellationToken);
            var requestInDb = await _requestMerchRepository.FindBySkuAsync(new Sku(request.Sku), cancellationToken);
            if (requestInDb is not null)
                throw new Exception($"Request merch item with sku {request.Sku} already exist");
            
            var newRequestMerch = new RequestMerch(
                new Sku(request.Sku),
                new MerchPack(MerchPackType.From(request.MerchPackType)),
                new Employee(request.EmployeeSku),
                request.RequestDateTime,
                new Quantity(request.Quantity), 
                Status.From(request.Status)
            );

            var createResult = await _requestMerchRepository.CreateAsync(newRequestMerch, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            return newRequestMerch.Id;
        }
    }
}