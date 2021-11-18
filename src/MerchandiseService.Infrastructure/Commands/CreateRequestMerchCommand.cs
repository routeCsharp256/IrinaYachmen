using System;
using MediatR;
using MerchandiseService.Domain.AggregatesModel;

namespace MerchandiseService.Infrastructure.Commands
{
    public class CreateRequestMerchCommand: IRequest<int>
    {
        /// <summary>
        /// Идентификатор новой заявки
        /// </summary>
        public long Sku { get; init; }
        
        /// <summary>
        /// Идентификатор сотруника, для которого выполняется запрос на мерч
        /// </summary>
        public long EmployeeSku { get; init; }

        /// <summary>
        /// Тип мерча
        /// </summary>
        public int MerchPackType { get; init; }

        /// <summary>
        /// Статус запроса
        /// </summary>
        public int Status { get; init; }

        /// <summary>
        /// Количество элементов 
        /// </summary>
        public int Quantity { get; init; }

        /// <summary>
        /// Дата запроса
        /// </summary>
        public DateTime RequestDateTime { get; init; }
    }
}