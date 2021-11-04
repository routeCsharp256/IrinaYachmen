using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.Contracts;
using MerchandiseService.Domain.ValueObjects;

namespace MerchandiseService.Domain.AggregatesModel
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        /// <summary>
        /// Найти сотрудника
        /// </summary>
        /// <param name="sku">идентификатор сотрудника</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Сотружник</returns>
        Task<Employee> FindBySkuAsync(Sku sku, CancellationToken cancellationToken = default);
    }
}