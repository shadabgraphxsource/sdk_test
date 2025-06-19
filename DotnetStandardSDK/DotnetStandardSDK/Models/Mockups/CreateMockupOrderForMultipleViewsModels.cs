using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DotnetStandardSDK.Models.Mockups
{
    internal class CreateMockupOrderForMultipleViewsModels
    {
    }

    #region[request original]
    public class CreateMockupOrderForMultipleViewsRequestOriginal
    {
        public string companyName { get; set; }
        public string PONumber { get; set; }
        public string mockupRequestType { get; set; }
        public MockupOrderProductOriginal mockupOrderProduct { get; set; }
    }

    public class MockupOrderProductOriginal
    {
        public string productPartID { get; set; }
        public int supplierID { get; set; }
        public List<MockupRequestOrderProductViewOriginal> mockupRequestOrderProductViews { get; set; }
    }

    public class MockupRequestOrderProductViewOriginal
    {
        public int productViewID { get; set; }
        public List<MockupRequestOrderProductViewLocationOriginal> mockupRequestOrderProductViewLocations { get; set; }
    }


    public class MockupRequestOrderProductViewLocationOriginal
    {
        public string locationName { get; set; }
        public string artURL { get; set; }
        public string instructions { get; set; }
    }
    #endregion

    #region[request]
    public class CreateMockupOrderForMultipleViewsRequest
    {
        public string customerName { get; set; }
        public string poNumber { get; set; }
        public string mockupRequestType { get; set; }
        public MockupOrderProduct mockupOrderProduct { get; set; }
    }

    public class MockupOrderProduct
    {
        public string productPartID { get; set; }
        public int supplierID { get; set; }
        public List<MockupRequestOrderProductView> mockupRequestOrderProductViews { get; set; }
    }

    public class MockupRequestOrderProductView
    {
        public int productViewID { get; set; }
        public List<MockupRequestOrderProductViewLocation> mockupRequestOrderProductViewLocations { get; set; }
    }


    public class MockupRequestOrderProductViewLocation
    {
        public string locationName { get; set; }
        public string artURL { get; set; }
        public string instructions { get; set; }
    }
    #endregion

    #region [response original]
    public class CreateMockupOrderForMultipleViewsResponseOriginal
    {
        public int orderID { get; set; }
        public string mockupOrderNumber { get; set; }
        public string outsourcedMockupOrderNumber { get; set; }
        public int outsourcedMockupOrderID { get; set; }
        public string mockupOrderStatus { get; set; }
        public MockupOrderProductResponseOriginal mockupOrderProductResponse { get; set; }
    }

    public class MockupOrderProductResponseOriginal
    {
        public string productTemplateOrderNumber { get; set; }
        public string productTemplateOrderStatus { get; set; }
        public string outsourcedProductTemplateOrderNumber { get; set; }
        public int outsourcedProductTemplateOrderID { get; set; }
        public List<MockupRequestOrderProductViewResponseOriginal> mockupRequestOrderProductViewResponse { get; set; }
    }

    public class MockupRequestOrderProductViewResponseOriginal
    {
        public string standardDecoratedProductURL { get; set; }
        public string premiumDecoratedProductURL { get; set; }
        public List<MockupRequestOrderProductViewLocationResponseOriginal> mockupRequestOrderProductViewLocationResponse { get; set; }
    }

    public class MockupRequestOrderProductViewLocationResponseOriginal
    {
        public string artOrderNumber { get; set; }
        public string outsourcedArtOrderReferenceNumber { get; set; }
        public int outsourcedArtOrderID { get; set; }
        public string artOrderStatus { get; set; }
        public string artURL { get; set; }
    }
    #endregion

    #region [response]
    public class CreateMockupOrderForMultipleViewsResponse
    {
        public int orderID { get; set; }
        public string mockupOrderNumber { get; set; }
        public string outsourcedMockupOrderNumber { get; set; }
        public int outsourcedMockupOrderID { get; set; }
        public string mockupOrderStatus { get; set; }
        public MockupOrderProductResponse mockupOrderProductResponse { get; set; }
    }

    public class MockupOrderProductResponse
    {
        public string productTemplateOrderNumber { get; set; }
        public string productTemplateOrderStatus { get; set; }
        public string outsourcedProductTemplateOrderNumber { get; set; }
        public int outsourcedProductTemplateOrderID { get; set; }
        public List<MockupRequestOrderProductViewResponse> mockupRequestOrderProductViewResponse { get; set; }
    }

    public class MockupRequestOrderProductViewResponse
    {
        public string standardDecoratedProductURL { get; set; }
        public string premiumDecoratedProductURL { get; set; }
        public List<MockupRequestOrderProductViewLocationResponse> mockupRequestOrderProductViewLocationResponse { get; set; }
    }

    public class MockupRequestOrderProductViewLocationResponse
    {
        public string artOrderNumber { get; set; }
        public string outsourcedArtOrderReferenceNumber { get; set; }
        public int outsourcedArtOrderID { get; set; }
        public string artOrderStatus { get; set; }
        public string artURL { get; set; }
    }
    #endregion
}
