using DotnetStandardSDK.Models;
using DotnetStandardSDK.Models.Products;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotnetStandardSDK.Controllers.Products
{
    internal interface IProductsClient
    {


        [Get("/api/ProductMockupRequest/GetProductListForCustomer")]
        Task<GenericPostResponseInfo<GetProductListForCustomerResponseOriginal>> GetProductListForCustomer([Query] string CustomerName, [Query] int Page);

        [Post("/api/ProductMockupRequest/GetProductPartsByProductID")]
        Task<GenericPostResponseInfo<List<ProductPartOriginal>>> GetProductPartsByProductID(GenericPostRequestInfo<GetProductPartsByProductIDRequestOriginal> rquest);

        [Get("/api/ProductMockupRequest/GetProductViews")]
        Task<GenericPostResponseInfo<List<ProductView>>> GetProductViews(string CompanyName, string ProductPartId, int supplierId, string code = null, bool isMockupRequestCall = false, string decorationType = null, string productViewCategory = null);
        [Get("/api/ProductMockupRequest/GetMappedSupplierLocationsForProduct")]
        Task<GenericPostResponseInfo<List<ProductPartMappedLocationOriginal>>> GetMappedSupplierLocationsForProduct([Query] string CompanyName, [Query] string ProductId, [Query] int supplierId);

        [Get("/api/ProductMockupRequest/GetSuppliersForCompany")]
        Task<GenericPostResponseInfo<List<SupplierOriginal>>> GetSuppliersForCompany([Query] string CompanyName);

        [Get("/api/ProductMockupRequest/GetProductPartDetails")]
        Task<GenericPostResponseInfo<ProductData>> GetProductPartDetails([Query] string companyName, [Query] string productPartId, [Query] int supplierId);
        

        [Post("/api/Product/GetProductPartIDOnStyleNumber")]
        Task<GenericPostResponseInfo<GetProductPartIDOnStyleNumberResponse>> GetProductPartIDOnStyleNumber(GenericPostRequestInfo<ProductStyleDetails> request);

        [Post("/api/EndPoint/GetProductMapStatusOnImageURL")]
        Task<GenericPostResponseInfo<GetProductMapStatusOnImageURLResponse>> GetProductMapStatusOnImageURL(GenericPostRequestInfo<GetProductMapStatusOnImageURLRequestOriginal> request);

        [Get("/api/ProductLine/GetAllProductColors")]
        Task<GenericPostResponseInfo<GetAllProductColorsResponse>> GetAllProductColors([Query] string customerName);
    }
}