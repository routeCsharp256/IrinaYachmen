using System;
using System.Collections.Generic;
using System.Linq;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregatesModel
{
    public class Status
        : Enumeration
    {
        public static Status Cancelled = new Status(1, nameof(Cancelled).ToLowerInvariant());
        public static Status Awaiting = new Status(2, nameof(Awaiting).ToLowerInvariant());
        public static Status RequestConfirmed = new Status(3, nameof(RequestConfirmed).ToLowerInvariant());
        public static Status Successed = new Status(4, nameof(Successed).ToLowerInvariant());
        

        public Status(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<Status> List() =>
            new[] { RequestConfirmed, Successed, Awaiting, Cancelled };
        
        public static Status From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new ArgumentException($"Possible values for Status: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
        
    }
}