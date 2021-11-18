using System.Threading.Tasks;
using Grpc.Core;
using MerchandiseService.Grpc;

namespace MerchandiseService.GrpcServices
{
    public class MerchandiseGrpcService: MerchandiseServiceGrpc.MerchandiseServiceGrpcBase
    {
        public override async Task<RequestMerchResponse> RequestMerch(RequestMerchRequest request, ServerCallContext context)
        {
            return new RequestMerchResponse
            {
                
            };
            
        }

        public override async Task<GetInformationAboutIssueOfMerchResponse> GetInformationAboutIssueOfMerch(GetInformationAboutIssueOfMerchRequest request, ServerCallContext context)
        {
            return new GetInformationAboutIssueOfMerchResponse();
        }
    }
}