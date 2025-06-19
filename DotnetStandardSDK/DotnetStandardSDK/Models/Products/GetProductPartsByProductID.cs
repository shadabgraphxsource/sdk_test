using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetStandardSDK.Models.Products
{
    internal class GetProductPartsByProductID
    {
    }
    public class GetProductPartsByProductIDRequest
    {
        public string customerName { get; set; }
        public string productID { get; set; }
    }

    public class GetProductPartsByProductIDRequestOriginal
    {
        public string companyName { get; set; }
        public string productID { get; set; }
    }

    public class ProductPart
    {
        public string productPartID { get; set; }
        public string color { get; set; }
    }

    public class ProductPartOriginal
    {
        public string productPartId { get; set; }
        public string color { get; set; }
    }

    public class GetProductPartsByProductIDResponseOriginal
    {
        public List<ProductPartOriginal> data { get; set; }
    }

    public class GetProductPartsByProductIDResponse
    {
        public List<ProductPart> data { get; set; }
    }


}
