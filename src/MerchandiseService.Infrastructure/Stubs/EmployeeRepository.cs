using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregatesModel;
using MerchandiseService.Domain.Contracts;
using MerchandiseService.Domain.ValueObjects;

namespace MerchandiseService.Infrastructure.Stubs
{
    public class EmployeeRepository: IEmployeeRepository 
    {
        public IUnitOfWork UnitOfWork { get; }
        public Task<Employee> CreateAsync(Employee itemToCreate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> UpdateAsync(Employee itemToUpdate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> FindBySkuAsync(Sku sku, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}