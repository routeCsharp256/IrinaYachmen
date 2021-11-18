using System;
using MerchandiseService.Domain.Exceptions;
using MerchandiseService.Domain.Models;
using MerchandiseService.Domain.ValueObjects;

namespace MerchandiseService.Domain.AggregatesModel
{
    public class RequestMerch : Entity
    {
        public Sku Sku { get; }

        public MerchPack MerchPackType { get; }
        
        public Status Status { get; }

        public Employee Employee { get; private set; }

        public Quantity Quantity { get; private set; }

        public DateTime RequestDateTime { get; set; }
        
        

        public RequestMerch(Sku sku,
            MerchPack merchPackType,
            Employee employee,
            DateTime date,
            Quantity quantity,
            Status status)
        {
            Sku = sku;
            MerchPackType = merchPackType;
            SetEmployee(employee);
            SetQuantity(quantity);
            RequestDateTime = date;
            Status = status;
        }
        
        private void SetQuantity(Quantity value)
        {
            if (value.Value < 0)
                throw new NegativeValueException($"{nameof(value)} value is negative");

            Quantity = value;
        }
        
        private void SetEmployee(Employee value)
        {
            if (value is null)
                throw new NullReferenceException($"{nameof(value)} value is null");

            Employee = value;
        }

        public void IncreaseQuantity(int valueToIncrease)
        {
            if (valueToIncrease < 0)
                throw new NegativeValueException($"{nameof(valueToIncrease)} value is negative");
            Quantity = new Quantity(this.Quantity.Value + valueToIncrease);
        }
    }
}
