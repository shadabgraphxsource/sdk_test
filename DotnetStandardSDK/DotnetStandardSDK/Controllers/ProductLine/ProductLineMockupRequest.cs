using DotnetStandardSDK.Models;
using DotnetStandardSDK.Models.Mockups;
using DotnetStandardSDK.Models.ProductLine;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetStandardSDK.Controllers.ProductLine
{
    internal class ProductLineMockupsClient
    {
    }
    internal interface IProductLineMockupsClient
    {
        [Get("/api/ProductLine/GetAllProductLines")]
        Task<GenericPostResponseInfo<List<GetAllProductLinesResponse>>> GetAllProductLines(string customerName);
        [Post("/api/ProductMockupRequest/GetProductLineMockupRequestExternal")]
        Task<GenericPostResponseInfo<GetProductLineMockupRequestExternalResponseOriginal>> GetProductLineMockupRequestExternal(GenericPostRequestInfo<GetProductLineMockupRequestExternalRequestOriginal> getProductLineMockupRequestStatusRequest);

        [Post("/api/ProductMockupRequest/GetProductLineMockupRequestStatus")]
        Task<GenericPostResponseInfo<GetProductLineMockupRequestStatusResponseOriginal>> GetProductLineMockupRequestStatus(GenericPostRequestInfo<GetProductLineMockupRequestStatusRequestOriginal> getProductLineMockupRequestStatusRequest);
    }
}
