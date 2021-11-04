using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.ValueObjects
{
    public class Sku : ValueObject
    {
    public long Value { get; }
        
    public Sku(long sku)
    {
        Value = sku;
    }
        
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    }
}