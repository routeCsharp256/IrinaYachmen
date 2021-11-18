using System.Collections.Generic;
using MerchandiseService.Infrastructure.Models;

namespace MerchandiseService.Infrastructure.Queries.Responses
{
    public class GetInfoAboutRequestMerchResponse: IItemsModel<RequestMerchDto>
    {
        
        public IReadOnlyList<RequestMerchDto> Items { get; set; }
        
    }
}