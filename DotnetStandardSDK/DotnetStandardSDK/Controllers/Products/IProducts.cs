using DotnetStandardSDK.Models;
using DotnetStandardSDK.Models.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotnetStandardSDK.Controllers.Products
{
    public interface IProducts
    {
        Task<Result<GetProductListForCustomerResponse>> GetProductListForCustomer(string customerName, int page = 1);
        Task<Result<List<ProductPart>>> GetProductPartsByProductID(GetProductPartsByProductIDRequest request);
        Task<Result<List<ProductView>>> GetProductViews(string customerName, string productPartId, int supplierId);
        Task<Result<List<ProductPartMappedLocation>>> GetMappedSupplierLocationsForProduct(string customerName, string productId, int supplierId);
        Task<Result<List<Supplier>>> GetSuppliersForCompany(string customerName);
        Task<Result<ProductData>> GetProductPartDetails(string customerName, string productPartId, int supplierId);
        Task<Result<GetProductPartIDOnStyleNumberResponse>> GetProductPartIDOnStyleNumber(ProductStyleDetails productStyleDetails);
        Task<Result<GetProductMapStatusOnImageURLResponse>> GetProductMapStatusOnImageURL(GetProductMapStatusOnImageURLRequest getProductMapStatusOnImageURLRequest);
        Task<Result<List<ProductBaseColor>>> GetAllProductColors(string customerName);
    }
}