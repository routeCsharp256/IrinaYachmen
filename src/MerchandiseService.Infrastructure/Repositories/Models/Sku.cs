using System.Diagnostics.CodeAnalysis;

namespace MerchandiseService.Infrastructure.Repositories.Models
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class Sku
    {
        public long Id { get; set; }

        public int MerchTypeId { get; set; }
        
    }
}