using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetStandardSDK.Models.Products
{
    internal class GetProductViews
    {
    }
    public class ProductViewCategory
    {
        public int id { get; set; }
        public string title { get; set; }
        public string code { get; set; }
    }

    public class ProductView
    {
        public int id { get; set; }
        public string title { get; set; }
        public string code { get; set; }
        public bool isDefault { get; set; }
        public ProductViewCategory productViewCategory { get; set; }
    }

    public class GetProductViewsResponse
    {
        public List<ProductView> data { get; set; }
    }
}
