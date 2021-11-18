using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Models;

namespace MerchandiseService.Services.Interfaces
{
    public interface IMerchandiseService
    {
        Task RequestMerch(long id, CancellationToken token);
        Task<List<MerchandiseItem>> GetInformationAboutIssueOfMerch(CancellationToken token);
    }
}