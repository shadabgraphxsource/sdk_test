using DotnetStandardSDK.Models;
using DotnetStandardSDK.Models.ProductLine;
using DotnetStandardSDK.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotnetStandardSDK.Controllers.ProductLine
{
    internal class ProductLineMockups : IProductLineMockups
    {
        private readonly IProductLineMockupsClient _productLineMockupsClient;

        public ProductLineMockups(IProductLineMockupsClient productLineMockupsClient)
        {
            _productLineMockupsClient = productLineMockupsClient;
        }

        public async Task<Result<List<GetAllProductLinesResponse>>> GetAllProductLines(string customerName)
        {
            try
            {
                var response = await _productLineMockupsClient.GetAllProductLines(customerName);
                var resultInfo = new GenericPostResponseInfo<List<GetAllProductLinesResponse>>
                {
                    Status = response.Status,
                    ErrorCode = response.ErrorCode,
                    ErrorMessage = response.ErrorMessage,
                    Error = response.Error,
                    TObject = response.TObject
                };
                return ApplicationConstants.ToResult<List<GetAllProductLinesResponse>>(resultInfo);
            }
            catch (Exception ex)
            {
                return Result<List<GetAllProductLinesResponse>>.Failure(new Error { code = "Exception", message = ex.Message });
            }
        }

        public async Task<Result<GetProductLineMockupRequestExternalResponse>> GetProductLineMockupRequestExternal(GetProductLineMockupRequestExternalRequest getProductLineMockupRequestExternalRequest)
        {
            try
            {
                var requestOriginal = ApplicationConstants.GenericTypeMapper.Map<GetProductLineMockupRequestExternalRequest, GetProductLineMockupRequestExternalRequestOriginal>(getProductLineMockupRequestExternalRequest);
                var apiRequest = new GenericPostRequestInfo<GetProductLineMockupRequestExternalRequestOriginal> { TObject = requestOriginal };
                var apiResponse = await _productLineMockupsClient.GetProductLineMockupRequestExternal(apiRequest);
                var mapped = ApplicationConstants.GenericTypeMapper.Map<GetProductLineMockupRequestExternalResponseOriginal, GetProductLineMockupRequestExternalResponse>(apiResponse.TObject);
                var resultInfo = new GenericPostResponseInfo<GetProductLineMockupRequestExternalResponse>
                {
                    Status = apiResponse.Status,
                    ErrorCode = apiResponse.ErrorCode,
                    ErrorMessage = apiResponse.ErrorMessage,
                    Error = apiResponse.Error,
                    TObject = mapped
                };
                return ApplicationConstants.ToResult<GetProductLineMockupRequestExternalResponse>(resultInfo);
            }
            catch (Exception ex)
            {
                return Result<GetProductLineMockupRequestExternalResponse>.Failure(new Error { code = "Exception", message = ex.Message });
            }
        }

        public async Task<Result<GetProductLineMockupRequestStatusResponse>> GetProductLineMockupRequestStatus(GetProductLineMockupRequestStatusRequest getProductLineMockupRequestStatusRequest)
        {
            try
            {
                var requestOriginal = ApplicationConstants.GenericTypeMapper.Map<GetProductLineMockupRequestStatusRequest, GetProductLineMockupRequestStatusRequestOriginal>(getProductLineMockupRequestStatusRequest);
                var apiRequest = new GenericPostRequestInfo<GetProductLineMockupRequestStatusRequestOriginal> { TObject = requestOriginal };
                var response = await _productLineMockupsClient.GetProductLineMockupRequestStatus(apiRequest);
                var mapped = ApplicationConstants.GenericTypeMapper.Map<GetProductLineMockupRequestStatusResponseOriginal, GetProductLineMockupRequestStatusResponse>(response.TObject);

                var resultInfo = new GenericPostResponseInfo<GetProductLineMockupRequestStatusResponse>
                {
                    Status = response.Status,
                    ErrorCode = response.ErrorCode,
                    ErrorMessage = response.ErrorMessage,
                    Error = response.Error,
                    TObject = mapped
                };
                return ApplicationConstants.ToResult<GetProductLineMockupRequestStatusResponse>(resultInfo);
            }
            catch (Exception ex)
            {
                return Result<GetProductLineMockupRequestStatusResponse>.Failure(new Error { code = "Exception", message = ex.Message });
            }
        }
    }
}