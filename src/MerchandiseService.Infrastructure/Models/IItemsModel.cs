using System.Collections.Generic;

namespace MerchandiseService.Infrastructure.Models
{
    public interface IItemsModel<TItemsModel>
        where TItemsModel : class
    {
        IReadOnlyList<TItemsModel> Items { get; set; }
    }
}