using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregatesModel
{
    public class MerchPack: Entity
    {
        public MerchPackType Type { get; }

        public MerchPack(MerchPackType type)
        {
            Type = type;
        }
    }
}