using System;

namespace MerchandiseService.HttpModels
{
    public class MerchandiseItemResponse
    {
        public long ItemId { get; set; }
        
        public string ItemName { get; set; }
        
        public int Quantity { get; set; }
    }
}