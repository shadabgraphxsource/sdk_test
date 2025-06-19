using DotnetStandardSDK.Models;
using DotnetStandardSDK.Models.Mockups;
using DotnetStandardSDK.Utilities;
using System;
using System.Threading.Tasks;

namespace DotnetStandardSDK.Controllers.Mockups
{
    internal class Mockups : IMockups
    {
        private readonly IProductMockupRequestClient _productClient;

        public Mockups(IProductMockupRequestClient productClient)
        {
            _productClient = productClient;
        }

        public async Task<Result<GetProductMockupRequestExternalResponse>> GetProductMockupRequestExternal(GetProductMockupRequestExternalRequest request)
        {
            try
            {
                var requestOriginal = ApplicationConstants.GenericTypeMapper.Map<GetProductMockupRequestExternalRequest, ProductMockupRequestExternalRequestOriginal>(request);
                var apiRequest = new GenericPostRequestInfo<ProductMockupRequestExternalRequestOriginal> { TObject = requestOriginal };
                var apiResponse = await _productClient.GetProductMockupRequestExternal(apiRequest);
                var mapped = ApplicationConstants.GenericTypeMapper.Map<ProductMockupRequestExternalResponseOriginal, GetProductMockupRequestExternalResponse>(apiResponse.TObject);
                var resultInfo = new GenericPostResponseInfo<GetProductMockupRequestExternalResponse>
                {
                    Status = apiResponse.Status,
                    ErrorCode = apiResponse.ErrorCode,
                    ErrorMessage = apiResponse.ErrorMessage,
                    Error = apiResponse.Error,
                    TObject = mapped
                };
                return ApplicationConstants.ToResult<GetProductMockupRequestExternalResponse>(resultInfo);
            }
            catch (Exception ex)
            {
                return Result<GetProductMockupRequestExternalResponse>.Failure(new Error { code = "Exception", message = ex.Message });
            }
        }

        public async Task<Result<GetProductMockupRequestExternalResponse>> GetProductMockupRequestStatus(GetProductMockupRequestStatusRequest request)
        {
            try
            {
                var requestOriginal = ApplicationConstants.GenericTypeMapper.Map<GetProductMockupRequestStatusRequest, ProductMockupRequestStatusRequestOriginal>(request);
                var apiRequest = new GenericPostRequestInfo<ProductMockupRequestStatusRequestOriginal> { TObject = requestOriginal };
                var apiResponse = await _productClient.GetProductMockupRequestStatus(apiRequest);
                var mapped = ApplicationConstants.GenericTypeMapper.Map<ProductMockupRequestExternalResponseOriginal, GetProductMockupRequestExternalResponse>(apiResponse.TObject);
                var resultInfo = new GenericPostResponseInfo<GetProductMockupRequestExternalResponse>
                {
                    Status = apiResponse.Status,
                    ErrorCode = apiResponse.ErrorCode,
                    ErrorMessage = apiResponse.ErrorMessage,
                    Error = apiResponse.Error,
                    TObject = mapped
                };
                return ApplicationConstants.ToResult<GetProductMockupRequestExternalResponse>(resultInfo);
            }
            catch (Exception ex)
            {
                return Result<GetProductMockupRequestExternalResponse>.Failure(new Error { code = "Exception", message = ex.Message });
            }
        }

        public async Task<Result<CreateMockupOrderForMultipleViewsResponse>> CreateMockupOrderForMultipleViews(CreateMockupOrderForMultipleViewsRequest request)
        {
            try
            {
                var requestOriginal = ApplicationConstants.GenericTypeMapper.Map<CreateMockupOrderForMultipleViewsRequest, CreateMockupOrderForMultipleViewsRequestOriginal>(request);
                var apiRequest = new GenericPostRequestInfo<CreateMockupOrderForMultipleViewsRequestOriginal> { TObject = requestOriginal };
                var apiResponse = await _productClient.CreateMockupOrderForMultipleViews(apiRequest);
                var mapped = ApplicationConstants.GenericTypeMapper.Map<CreateMockupOrderForMultipleViewsResponseOriginal, CreateMockupOrderForMultipleViewsResponse>(apiResponse.TObject);
                var resultInfo = new GenericPostResponseInfo<CreateMockupOrderForMultipleViewsResponse>
                {
                    Status = apiResponse.Status,
                    ErrorCode = apiResponse.ErrorCode,
                    ErrorMessage = apiResponse.ErrorMessage,
                    Error = apiResponse.Error,
                    TObject = mapped
                };
                return ApplicationConstants.ToResult<CreateMockupOrderForMultipleViewsResponse>(resultInfo);
            }
            catch (Exception ex)
            {
                return Result<CreateMockupOrderForMultipleViewsResponse>.Failure(new Error { code = "Exception", message = ex.Message });
            }
        }

        public async Task<Result<CreateMockupOrderForMultipleViewsResponse>> GetStatusForMultipleViewMockup(GetStatusForMultipleViewMockupRequest request)
        {
            try
            {
                var apiRequest = new GenericPostRequestInfo<GetStatusForMultipleViewMockupRequest> { TObject = request };
                var apiResponse = await _productClient.GetStatusForMultipleViewMockup(apiRequest);
                var mapped = ApplicationConstants.GenericTypeMapper.Map<CreateMockupOrderForMultipleViewsResponseOriginal, CreateMockupOrderForMultipleViewsResponse>(apiResponse.TObject);
                var resultInfo = new GenericPostResponseInfo<CreateMockupOrderForMultipleViewsResponse>
                {
                    Status = apiResponse.Status,
                    ErrorCode = apiResponse.ErrorCode,
                    ErrorMessage = apiResponse.ErrorMessage,
                    Error = apiResponse.Error,
                    TObject = mapped
                };
                return ApplicationConstants.ToResult<CreateMockupOrderForMultipleViewsResponse>(resultInfo);
            }
            catch (Exception ex)
            {
                return Result<CreateMockupOrderForMultipleViewsResponse>.Failure(new Error { code = "Exception", message = ex.Message });
            }
        }
    }
}