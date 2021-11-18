using System;

namespace MerchandiseService.HttpModels
{
    public record RequestMerchandiseResponse
    {
        public long Sku { get; init; }
        
        public int MerchPackType { get; init; }
        
        public int Quantity { get; init; }
        
        public int Status { get; init; }
    }
}