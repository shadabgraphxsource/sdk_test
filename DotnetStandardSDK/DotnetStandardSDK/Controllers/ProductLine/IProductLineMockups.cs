using DotnetStandardSDK.Models;
using DotnetStandardSDK.Models.Mockups;
using DotnetStandardSDK.Models.ProductLine;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotnetStandardSDK.Controllers.ProductLine
{
    public interface IProductLineMockups
    {
        Task<Result<List<GetAllProductLinesResponse>>> GetAllProductLines(string customerName);
        Task<Result<GetProductLineMockupRequestExternalResponse>> GetProductLineMockupRequestExternal(GetProductLineMockupRequestExternalRequest getProductLineMockupRequestExternalRequest);
        Task<Result<GetProductLineMockupRequestStatusResponse>> GetProductLineMockupRequestStatus(GetProductLineMockupRequestStatusRequest getProductLineMockupRequestStatusRequest);
    }
}