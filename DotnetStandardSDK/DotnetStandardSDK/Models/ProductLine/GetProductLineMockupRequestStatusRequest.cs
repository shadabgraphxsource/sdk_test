using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetStandardSDK.Models.ProductLine
{
    public class GetProductLineMockupRequestStatusRequest
    {
        public string customerName { get; set; }
        public string productLineMockupOrderNumber { get; set; }
    }
    public class GetProductLineMockupRequestStatusRequestOriginal
    {
        public string companyName { get; set; }
        public string productLineMockupOrderNumber { get; set; }
    }

    public class GetProductLineMockupRequestStatusResponse
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
        public List<string> baseColorIDs { get; set; }
    }

    public class GetProductLineMockupRequestStatusResponseOriginal
    {
        public string companyName { get; set; }
        public string productLineMockupOrderNumber { get; set; }
        public string productLineMockupOrderStatus { get; set; }
        public bool autoRemoveArtBackground { get; set; }
        public List<ProductLineOrderArtDetail> productLineOrderArtDetails { get; set; }
        public List<ProductLine> productLine { get; set; }
        public string createdDate { get; set; }
        public string poNumber { get; set; }
        public string mockupOrderNumberFromUI { get; set; }
        public List<int> productLineIDs { get; set; }
        public List<string> baseColorIDs { get; set; }
    }
}
