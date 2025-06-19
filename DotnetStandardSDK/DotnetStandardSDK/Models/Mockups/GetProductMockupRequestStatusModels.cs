using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DotnetStandardSDK.Models.Mockups
{
    public class GetProductMockupRequestStatusModels
    {
    }

    #region [request]
    public class ProductMockupRequestStatusRequestOriginal
    {
        public string CompanyName { get; set; }
        public string MockupOrderNumber { get; set; }
    }

    public class GetProductMockupRequestStatusRequest
    {
        public string customerName { get; set; }
        public string mockupOrderNumber { get; set; }
    }
    #endregion

    #region [response]
    public class MockupRequestOrderExternalResponse
    {
        public int OrderID { get; set; }
        public string MockupOrderNumber { get; set; }
        public string OutsourcedMockupOrderNumber { get; set; }
        public int OutsourcedMockupOrderId { get; set; }
        public string MockupOrderStatus { get; set; }
        public List<MockupRequestOrderProductExternalResponse> MockupRequestOrderProductExternalResponse { get; set; }

    }
    #endregion
}
