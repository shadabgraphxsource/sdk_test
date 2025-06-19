using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetStandardSDK.Models.ProductLine
{
    public class ProductLineOrderArtDetail
    {
        public string artURL { get; set; }
        public string instructions { get; set; }
    }

    public class GetProductLineMockupRequestExternalRequest
    {
        public string customerName { get; set; }
        public string poNumber { get; set; }
        public List<ProductLineOrderArtDetail> productLineOrderArtDetails { get; set; }
        public List<string> productLineIDs { get; set; }
        public List<string> baseColorIDs { get; set; }
    }

    public class GetProductLineMockupRequestExternalRequestOriginal
    {
        public string companyName { get; set; }
        public string poNumber { get; set; }
        public List<ProductLineOrderArtDetail> productLineOrderArtDetails { get; set; }
        public List<string> productLineIds { get; set; }
        public List<string> baseColorIds { get; set; }
    }

    public class GetProductLineMockupRequestExternalResponse
    {
        public string customerName { get; set; }
        public string productLineMockupOrderNumber { get; set; }
        public string productLineMockupOrderStatus { get; set; }
        public bool autoRemoveArtBackground { get; set; }
        public List<ProductLineOrderArtDetail> productLineOrderArtDetails { get; set; }
        public List<ProductLine> productLine { get; set; }
        public string createdDate { get; set; }
        public string poNumber { get; set; }
        public string mockupOrderNumberFromUI { get; set; }
        public List<int> productLineIDs { get; set; }
        public List<int> baseColorIDs { get; set; }
    }

    public class ProductLine
    {
        public int productLineID { get; set; }
        public string productLineTitle { get; set; }
        public List<ProductLineMockupRequestOrderProduct> productLineMockupRequestOrderProduct { get; set; }
    }

    public class ProductLineMockupRequestOrderProduct
    {
        public string productMockupOrderNumber { get; set; }
        public string productMockupOrderStatus { get; set; }
        public string productPartID { get; set; }
        public int productViewID { get; set; }
        public int supplierID { get; set; }
        public string supplierName { get; set; }
        public string standardDecoratedProductURL { get; set; }
        public string premiumDecoratedProductURL { get; set; }
        public int outsourcedProductMockupOrderID { get; set; }
        public string outsourcedProductMockupOrderNumber { get; set; }
        public string outsourcedOrderErrorDescription { get; set; }
        public List<ProductLineMockupRequestOrderProductLocation> productLineMockupRequestOrderProductLocation { get; set; }
    }

    public class ProductLineMockupRequestOrderProductLocation
    {
        public string artOrderNumber { get; set; }
        public string artOrderStatus { get; set; }
        public string locationName { get; set; }
        public string instructions { get; set; }
        public string artURL { get; set; }
        public string outsourcedOrderReferenceNumber { get; set; }
        public int outsourcedArtOrderID { get; set; }
    }

    // API Classes
    public class GetProductLineMockupRequestExternalResponseOriginal
    {
        public string CompanyName { get; set; }
        public string ProductLineMockupOrderNumber { get; set; }
        public string ProductLineMockupOrderStatus { get; set; }
        public bool AutoRemoveArtBackground { get; set; } = false;
        public List<ProductLineOrderArtDetail> ProductLineOrderArtDetails { get; set; }
        public List<ProductLine> ProductLine { get; set; }
        public string CreatedDate { get; set; }
        public string PONumber { get; set; }
        public string MockupOrderNumberFromUI { get; set; }
        public List<int> ProductLineIds { get; set; }
        public List<int> BaseColorIds { get; set; }

    }

    public class ProductLineOrderArtDetailOriginal
    {
        public string artURL { get; set; }
        public string instructions { get; set; }
    }

    public class ProductLineOriginal
    {
        public int productLineId { get; set; }
        public string productLineTitle { get; set; }
        public List<ProductLineMockupRequestOrderProduct> productLineMockupRequestOrderProduct { get; set; }
    }

    public class ProductLineMockupRequestOrderProductOriginal
    {
        public string productMockupOrderNumber { get; set; }
        public string productMockupOrderStatus { get; set; }
        public string productPartId { get; set; }
        public int productViewId { get; set; }
        public int supplierId { get; set; }
        public string supplierName { get; set; }
        public string standardDecoratedProductURL { get; set; }
        public string premiumDecoratedProductURL { get; set; }
        public int outsourcedProductMockupOrderId { get; set; }
        public string outsourcedProductMockupOrderNumber { get; set; }
        public string outsourcedOrderErrorDescription { get; set; }
        public List<ProductLineMockupRequestOrderProductLocation> productLineMockupRequestOrderProductLocation { get; set; }
    }

    public class ProductLineMockupRequestOrderProductLocationOriginal
    {
        public string artOrderNumber { get; set; }
        public string artOrderStatus { get; set; }
        public string locationName { get; set; }
        public string instructions { get; set; }
        public string artURL { get; set; }
        public string outsourcedOrderReferenceNumber { get; set; }
        public int outsourcedArtOrderId { get; set; }
    }

}
