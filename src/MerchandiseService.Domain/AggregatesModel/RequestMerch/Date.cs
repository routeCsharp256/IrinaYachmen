using System;
using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregatesModel
{
    public class Date : ValueObject
    {
        public Date(DateTime value)
        {
            Value = value;
        }

        public DateTime Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}