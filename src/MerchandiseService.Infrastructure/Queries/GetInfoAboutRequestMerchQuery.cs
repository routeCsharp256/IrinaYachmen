using MediatR;

namespace MerchandiseService.Infrastructure.Queries
{
    public class GetInfoAboutRequestMerchQuery : IRequest<int>
    {
        /// <summary>
        /// Идентификатор заявки
        /// </summary>
        public long Sku { get; set; }
    }
}