using DotnetStandardSDK.Models;
using DotnetStandardSDK.Models.Products;
using DotnetStandardSDK.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotnetStandardSDK.Controllers.Products
{
    internal class Products : IProducts
    {
        private readonly IProductsClient _client;

        public Products(IProductsClient client)
        {
            _client = client;
        }

        public async Task<Result<GetProductListForCustomerResponse>> GetProductListForCustomer(string customerName, int page = 1)
        {
            try
            {
                var apiResponse = await _client.GetProductListForCustomer(customerName, page);
                var mapped = ApplicationConstants.GenericTypeMapper.Map<GetProductListForCustomerResponseOriginal, GetProductListForCustomerResponse>(apiResponse.TObject);
                var resultInfo = new GenericPostResponseInfo<GetProductListForCustomerResponse>
                {
                    Status = apiResponse.Status,
                    ErrorCode = apiResponse.ErrorCode,
                    ErrorMessage = apiResponse.ErrorMessage,
                    Error = apiResponse.Error,
                    TObject = mapped
                };
                return ApplicationConstants.ToResult<GetProductListForCustomerResponse>(resultInfo);
            }
            catch (Exception ex)
            {
                return Result<GetProductListForCustomerResponse>.Failure(new Error { code = "Exception", message = ex.Message });
            }
        }

        public async Task<Result<List<ProductPart>>> GetProductPartsByProductID(GetProductPartsByProductIDRequest getProductPartsByProductIDRequest)
        {
            try
            {
                var originalRequest = ApplicationConstants.GenericTypeMapper.Map<GetProductPartsByProductIDRequest, GetProductPartsByProductIDRequestOriginal>(getProductPartsByProductIDRequest);
                var apiRequest = new GenericPostRequestInfo<GetProductPartsByProductIDRequestOriginal> { TObject = originalRequest };
                var apiResponse = await _client.GetProductPartsByProductID(apiRequest);
                var mapped = ApplicationConstants.GenericTypeMapper.Map<List<ProductPartOriginal>, List<ProductPart>>(apiResponse.TObject);
                var resultInfo = new GenericPostResponseInfo<List<ProductPart>>
                {
                    Status = apiResponse.Status ?? "1", // apiResponse.Status, commenetd coz GetProductPartsByProductID action not returning status 1 in case of success, need to return 1 in case of success in api action
                    ErrorCode = apiResponse.ErrorCode,
                    ErrorMessage = apiResponse.ErrorMessage,
                    Error = apiResponse.Error,
                    TObject = mapped
                };
                return ApplicationConstants.ToResult<List<ProductPart>>(resultInfo);
            }
            catch (Exception ex)
            {
                return Result<List<ProductPart>>.Failure(new Error { code = "Exception", message = ex.Message });
            }
        }

        public async Task<Result<List<ProductView>>> GetProductViews(string companyName, string productPartId, int supplierId)
        {
            try
            {
                var apiResponse = await _client.GetProductViews(companyName, productPartId, supplierId);
                var mapped = ApplicationConstants.GenericTypeMapper.Map<List<ProductView>, List<ProductView>>(apiResponse.TObject);
                var resultInfo = new GenericPostResponseInfo<List<ProductView>>
                {
                    Status = apiResponse.Status,
                    ErrorCode = apiResponse.ErrorCode,
                    ErrorMessage = apiResponse.ErrorMessage,
                    Error = apiResponse.Error,
                    TObject = mapped
                };
                return ApplicationConstants.ToResult<List<ProductView>>(resultInfo);
            }
            catch (Exception ex)
            {
                return Result<List<ProductView>>.Failure(new Error { code = "Exception", message = ex.Message });
            }
        }

        public async Task<Result<List<ProductPartMappedLocation>>> GetMappedSupplierLocationsForProduct(string companyName, string productId, int supplierId)
        {
            try
            {
                var apiResponse = await _client.GetMappedSupplierLocationsForProduct(companyName, productId, supplierId);
                var mapped = ApplicationConstants.GenericTypeMapper.Map<List<ProductPartMappedLocationOriginal>, List<ProductPartMappedLocation>>(apiResponse.TObject);
                var resultInfo = new GenericPostResponseInfo<List<ProductPartMappedLocation>>
                {
                    Status = apiResponse.Status,
                    ErrorCode = apiResponse.ErrorCode,
                    ErrorMessage = apiResponse.ErrorMessage,
                    Error = apiResponse.Error,
                    TObject = mapped
                };
                return ApplicationConstants.ToResult<List<ProductPartMappedLocation>>(resultInfo);
            }
            catch (Exception ex)
            {
                return Result<List<ProductPartMappedLocation>>.Failure(new Error { code = "Exception", message = ex.Message });
            }
        }

        public async Task<Result<List<Supplier>>> GetSuppliersForCompany(string companyName)
        {
            try
            {
                var apiResponse = await _client.GetSuppliersForCompany(companyName);
                var mapped = ApplicationConstants.GenericTypeMapper.Map<List<SupplierOriginal>, List<Supplier>>(apiResponse.TObject);
                var resultInfo = new GenericPostResponseInfo<List<Supplier>>
                {
                    Status = apiResponse.Status,
                    ErrorCode = apiResponse.ErrorCode,
                    ErrorMessage = apiResponse.ErrorMessage,
                    Error = apiResponse.Error,
                    TObject = mapped
                };
                return ApplicationConstants.ToResult<List<Supplier>>(resultInfo);
            }
            catch (Exception ex)
            {
                return Result<List<Supplier>>.Failure(new Error { code = "Exception", message = ex.Message });
            }
        }

        public async Task<Result<ProductData>> GetProductPartDetails(string companyName, string productPartId, int supplierId)
        {
            try
            {
                var apiResponse = await _client.GetProductPartDetails(companyName, productPartId, supplierId);
                //var mapped = ApplicationConstants.GenericTypeMapper.Map<GetProductPartDetailsResponse, ProductData>(apiResponse.TObject);
                var resultInfo = new GenericPostResponseInfo<ProductData>
                {
                    Status = apiResponse.Status,
                    ErrorCode = apiResponse.ErrorCode,
                    ErrorMessage = apiResponse.ErrorMessage,
                    Error = apiResponse.Error,
                    TObject = apiResponse.TObject
                };
                return ApplicationConstants.ToResult<ProductData>(resultInfo);
            }
            catch (Exception ex)
            {
                return Result<ProductData>.Failure(new Error { code = "Exception", message = ex.Message });
            }
        }

        //pending testing - with proper data
        public async Task<Result<GetProductPartIDOnStyleNumberResponse>> GetProductPartIDOnStyleNumber(ProductStyleDetails productStyleDetails)
        {
            try
            {
                var apiRequest = new GenericPostRequestInfo<ProductStyleDetails> { TObject = productStyleDetails };
                var apiResponse = await _client.GetProductPartIDOnStyleNumber(apiRequest);
                var resultInfo = new GenericPostResponseInfo<GetProductPartIDOnStyleNumberResponse>
                {
                    Status = apiResponse.Status ?? "1", // apiResponse.Status, commenetd coz GetProductPartsByProductID action not returning status 1 in case of success, need to return 1 in case of success in api action
                    ErrorCode = apiResponse.ErrorCode,
                    ErrorMessage = apiResponse.ErrorMessage,
                    Error = apiResponse.Error,
                    TObject = apiResponse.TObject
                };
                return ApplicationConstants.ToResult<GetProductPartIDOnStyleNumberResponse>(resultInfo);
            }
            catch (Exception ex)
            {
                return Result<GetProductPartIDOnStyleNumberResponse>.Failure(new Error { code = "Exception", message = ex.Message });
            }
        }

        public async Task<Result<GetProductMapStatusOnImageURLResponse>> GetProductMapStatusOnImageURL(GetProductMapStatusOnImageURLRequest getProductMapStatusOnImageURLRequest)
        {
            try
            {
                var getProductMapStatusOnImageURLRequestOriginal = ApplicationConstants.GenericTypeMapper.Map<GetProductMapStatusOnImageURLRequest, GetProductMapStatusOnImageURLRequestOriginal>(getProductMapStatusOnImageURLRequest);
                var apiRequest = new GenericPostRequestInfo<GetProductMapStatusOnImageURLRequestOriginal> { TObject = getProductMapStatusOnImageURLRequestOriginal, TObjectLst=new List<GetProductMapStatusOnImageURLRequestOriginal>() };
                var apiResponse = await _client.GetProductMapStatusOnImageURL(apiRequest);
                var resultInfo = new GenericPostResponseInfo<GetProductMapStatusOnImageURLResponse>
                {
                    Status = apiResponse.Status,
                    ErrorCode = apiResponse.ErrorCode,
                    ErrorMessage = apiResponse.ErrorMessage,
                    Error = apiResponse.Error,
                    TObject = apiResponse.TObject
                };
                return ApplicationConstants.ToResult<GetProductMapStatusOnImageURLResponse>(resultInfo);
            }
            catch (Exception ex)
            {
                return Result<GetProductMapStatusOnImageURLResponse>.Failure(new Error { code = "Exception", message = ex.Message });
            }
        }

        public async Task<Result<List<ProductBaseColor>>> GetAllProductColors(string customerName)
        {
            try
            {
                var apiResponse = await _client.GetAllProductColors(customerName);
                var resultInfo = new GenericPostResponseInfo<List<ProductBaseColor>>
                {
                    Status = apiResponse.Status,
                    ErrorCode = apiResponse.ErrorCode,
                    ErrorMessage = apiResponse.ErrorMessage,
                    Error = apiResponse.Error,
                    TObject = apiResponse.TObject.data
                };
                return ApplicationConstants.ToResult<List<ProductBaseColor>>(resultInfo);
            }
            catch (Exception ex)
            {
                return Result<List<ProductBaseColor>>.Failure(new Error { code = "Exception", message = ex.Message });
            }
        }
    }
}