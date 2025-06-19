using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetStandardSDK.Models.Products
{
    internal class GetProductPartIDOnStyleNumberRequest
    {
    }
    public class ProductStyleDetails
    {
        public string styleNumber { get; set; }
        public string productColor { get; set; }
        public List<string> sizes { get; set; }
        public int supplierID { get; set; }
        public string productImage { get; set; }
        public string productTitle { get; set; }
        public List<string> productLocations { get; set; }
        public bool isProductPartAvailable { get; set; } = false;
    }

    public class GetProductPartIDOnStyleNumberResponse
    {
        public string productPartID { get; set; }
    }
}
