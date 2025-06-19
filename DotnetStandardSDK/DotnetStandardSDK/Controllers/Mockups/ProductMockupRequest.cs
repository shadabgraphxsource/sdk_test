using DotnetStandardSDK.Models;
using DotnetStandardSDK.Models.Mockups;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetStandardSDK.Controllers.Mockups
{
    internal class ProductMockupRequest
    {
    }
    internal interface IProductMockupRequestClient
    {
        [Post("/api/ProductMockupRequest/GetProductMockupRequestExternal")]
        Task<GenericPostResponseInfo<ProductMockupRequestExternalResponseOriginal>> GetProductMockupRequestExternal(GenericPostRequestInfo<ProductMockupRequestExternalRequestOriginal> getProductMockupRequestExternalRequest);
        [Post("/api/ProductMockupRequest/GetProductMockupRequestStatus")]
        Task<GenericPostResponseInfo<ProductMockupRequestExternalResponseOriginal>> GetProductMockupRequestStatus(GenericPostRequestInfo<ProductMockupRequestStatusRequestOriginal> getProductMockupRequestStatusRequest);

        [Post("/api/ProductMockupRequest/CreateMockupOrderForMultipleViews")]
        Task<GenericPostResponseInfo<CreateMockupOrderForMultipleViewsResponseOriginal>> CreateMockupOrderForMultipleViews(GenericPostRequestInfo<CreateMockupOrderForMultipleViewsRequestOriginal> createMockupOrderForMultipleViewsRequest);

        [Post("/api/ProductMockupRequest/GetStatusForMultipleViewMockup")]
        Task<GenericPostResponseInfo<CreateMockupOrderForMultipleViewsResponseOriginal>> GetStatusForMultipleViewMockup(GenericPostRequestInfo<GetStatusForMultipleViewMockupRequest> getStatusForMultipleViewMockupRequest);

    }
}
