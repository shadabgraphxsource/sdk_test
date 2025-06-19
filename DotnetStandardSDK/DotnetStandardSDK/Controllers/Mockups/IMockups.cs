using DotnetStandardSDK.Models;
using DotnetStandardSDK.Models.Mockups;
using Refit;
using System.Threading.Tasks;

namespace DotnetStandardSDK.Controllers.Mockups
{
    public interface IMockups
    {
        Task<Result<GetProductMockupRequestExternalResponse>> GetProductMockupRequestExternal(GetProductMockupRequestExternalRequest getProductMockupRequestExternalRequest);
        Task<Result<GetProductMockupRequestExternalResponse>> GetProductMockupRequestStatus(GetProductMockupRequestStatusRequest getProductMockupRequestStatusRequest);
        Task<Result<CreateMockupOrderForMultipleViewsResponse>> CreateMockupOrderForMultipleViews(CreateMockupOrderForMultipleViewsRequest createMockupOrderForMultipleViewsRequest);
        Task<Result<CreateMockupOrderForMultipleViewsResponse>> GetStatusForMultipleViewMockup(GetStatusForMultipleViewMockupRequest getStatusForMultipleViewMockupRequest);

    }
}