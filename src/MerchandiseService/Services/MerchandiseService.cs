using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Models;
using MerchandiseService.Services.Interfaces;

namespace MerchandiseService.Services
{
    public class MerchandiseService : IMerchandiseService
    {
        public Task RequestMerch(long id, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<MerchandiseItem>> GetInformationAboutIssueOfMerch(CancellationToken token)
        {
            throw new System.NotImplementedException();
        }
    }
}