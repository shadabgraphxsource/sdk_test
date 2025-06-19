using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetStandardSDK.Models.Mockups
{
    #region [request]
    public class MockupRequestOrderProductOriginal
    {
        public string supplierId { get; set; }
        public string ProductPartId { get; set; }
        public int ProductViewId { get; set; }
        public List<MockupRequestOrderProductLocationOriginal> mockupRequestOrderProductLocation { get; set; }
    }

    public class MockupRequestOrderProductLocationOriginal
    {
        public string LocationName { get; set; }
        public string artURL { get; set; }
        public string instructions { get; set; }
    }

    public class ProductMockupRequestExternalRequestOriginal
    {
        public string CompanyName { get; set; }
        public string mockupRequestType { get; set; }
        public string PONumber { get; set; }
        public List<MockupRequestOrderProductOriginal> mockupRequestOrderProduct { get; set; }
    }

    public class GetProductMockupRequestExternalRequest

    {
        public string customerName { get; set; }
        public string mockupRequestType { get; set; }
        public string poNumber { get; set; }
        public List<MockupRequestOrderProduct> mockupRequestOrderProduct { get; set; }
    }

    public class MockupRequestOrderProduct
    {
        public string supplierID { get; set; }
        public string productPartID { get; set; }
        public int productViewID { get; set; }
        public List<MockupRequestOrderProductLocation> mockupRequestOrderProductLocation { get; set; }
    }

    public class MockupRequestOrderProductLocation
    {
        public string locationName { get; set; }
        public string artURL { get; set; }
        public string instructions { get; set; }
    }
    #endregion

    #region [response]
    
    public class MockupRequestOrderProductExternalResponseOriginal
    {
        public string productTemplateOrderNumber { get; set; }
        public string outsourcedProductTemplateOrderNumber { get; set; }
        public int outsourcedProductTemplateOrderId { get; set; }
        public string standardDecoratedProductURL { get; set; }
        public string premiumDecoratedProductURL { get; set; }
        public string productTemplateOrderStatus { get; set; }
        public List<MockupRequestOrderProductLocationExternalResponseOriginal> mockupRequestOrderProductLocationExternalResponse { get; set; }
    }

    public class MockupRequestOrderProductLocationExternalResponseOriginal
    {
        public string artOrderNumber { get; set; }
        public string outsourcedOrderReferenceNumber { get; set; }
        public int outsourcedArtOrderId { get; set; }
        public string artOrderStatus { get; set; }
        public string artURL { get; set; }
    }

    public class ProductMockupRequestExternalResponseOriginal
    {
        public int orderID { get; set; }
        public string mockupOrderNumber { get; set; }
        public string outsourcedMockupOrderNumber { get; set; }
        public int outsourcedMockupOrderId { get; set; }
        public string mockupOrderStatus { get; set; }
        public List<MockupRequestOrderProductExternalResponseOriginal> mockupRequestOrderProductExternalResponse { get; set; }
    }

    public class GetProductMockupRequestExternalResponse
    {
        public int orderID { get; set; }
        public string mockupOrderNumber { get; set; }
        public string outsourcedMockupOrderNumber { get; set; }
        public int outsourcedMockupOrderID { get; set; }
        public string mockupOrderStatus { get; set; }
        public List<MockupRequestOrderProductExternalResponse> mockupRequestOrderProductExternalResponse { get; set; }
    }

    public class MockupRequestOrderProductExternalResponse
    {
        public string productTemplateOrderNumber { get; set; }
        public string outsourcedProductTemplateOrderNumber { get; set; }
        public int outsourcedProductTemplateOrderID { get; set; }
        public string standardDecoratedProductURL { get; set; }
        public string premiumDecoratedProductURL { get; set; }
        public string productTemplateOrderStatus { get; set; }
        public List<MockupRequestOrderProductLocationExternalResponse> mockupRequestOrderProductLocationExternalResponse { get; set; }
    }

    public class MockupRequestOrderProductLocationExternalResponse
    {
        public string artOrderNumber { get; set; }
        public string outsourcedOrderReferenceNumber { get; set; }
        public int outsourcedArtOrderID { get; set; }
        public string artOrderStatus { get; set; }
        public string artURL { get; set; }
    }

    #endregion
}
