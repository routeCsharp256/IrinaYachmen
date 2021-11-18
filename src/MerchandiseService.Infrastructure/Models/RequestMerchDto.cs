using System;

namespace MerchandiseService.Infrastructure.Models
{
    public class RequestMerchDto
    {
        public long Sku { get; init; }
        
        public int MerchPackType { get; init; }
        
        public int Quantity { get; init; }
        
        public int Status { get; init; }

        public DateTime RequestDateTime { get; init; }
    }
}