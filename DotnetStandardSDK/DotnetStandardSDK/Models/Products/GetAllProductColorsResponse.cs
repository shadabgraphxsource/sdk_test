using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetStandardSDK.Models.Products
{
    public class ProductBaseColor
    {
        public int id { get; set; }
        public string title { get; set; }
        public string hex { get; set; }
    }

    public class GetAllProductColorsResponse
    {
        public List<ProductBaseColor> data { get; set; }
    }
}
