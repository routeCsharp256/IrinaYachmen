using System;
using System.Diagnostics.CodeAnalysis;

namespace MerchandiseService.Infrastructure.Repositories.Models
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class RequestMerch
    {
        public long Id { get; set; }
        
        public long SkuId { get; set; }
        
        public long EmployeeId { get; set; }
        
        public int Quantity { get; set; }

        public DateTime Date { get; set; }      
        
    }
}