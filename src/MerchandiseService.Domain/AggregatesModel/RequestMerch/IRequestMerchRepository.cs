using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.Contracts;
using MerchandiseService.Domain.ValueObjects;

namespace MerchandiseService.Domain.AggregatesModel
{
    public interface IRequestMerchRepository : IRepository<RequestMerch>
    {
        /// <summary>
        /// Найти запрос на выдачу мерча по сотруднику и типу мерча
        /// </summary>
        /// <param name="sku">идентификатор заявки</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Товарная позиция</returns>
        Task<RequestMerch> FindBySkuAsync(Sku sku, CancellationToken cancellationToken = default);
    }
}