using MediatR;
using MerchandiseService.Infrastructure.Queries.Responses;

namespace MerchandiseService.Infrastructure.Queries
{
    public class GetInfoAboutRequestMerchQuery : IRequest<GetInfoAboutRequestMerchResponse>
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public long Sku { get; set; }
    }
}