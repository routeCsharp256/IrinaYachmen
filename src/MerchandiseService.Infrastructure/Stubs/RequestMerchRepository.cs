using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregatesModel;
using MerchandiseService.Domain.Contracts;
using MerchandiseService.Domain.ValueObjects;

namespace MerchandiseService.Infrastructure.Stubs
{
    public class RequestMerchRepository : IRequestMerchRepository
    {
        public IUnitOfWork UnitOfWork { get; }
        public Task<RequestMerch> CreateAsync(RequestMerch itemToCreate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<RequestMerch> UpdateAsync(RequestMerch itemToUpdate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<RequestMerch> FindBySkuAsync(Sku sku, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}