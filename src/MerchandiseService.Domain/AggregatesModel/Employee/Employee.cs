using MerchandiseService.Domain.Models;
using MerchandiseService.Domain.ValueObjects;

namespace MerchandiseService.Domain.AggregatesModel
{
    public class Employee : Entity
    {
        public Sku Sku { get; set; }

        public Name Name { get; set; }

        public Employee(long sku)
        {
            Sku = new Sku(sku);
        }
    }
}