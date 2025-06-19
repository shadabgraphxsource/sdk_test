using DotnetStandardSDK.Models.Products.GetProductPartDetails;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace DotnetStandardSDK.Models.Products
{
    internal class GetProductPartDetailsResponse
    {
    }

    public class ProductData
    {
        public Product product { get; set; }
        public List<BaseApparelSize> baseApparelSize { get; set; }
        public List<SupplierApparelSize> supplierApparelSize { get; set; }
        public ProductPartIDSelected productPartIDSelected { get; set; }
        public List<ProductViewsDetail> productViewsDetail { get; set; }
    }
    public class BaseApparelSize
    {
        public int id { get; set; }
        public string labelSize { get; set; }
    }
    public class SupplierApparelSize
    {
        public int id { get; set; }
        public string labelSize { get; set; }
        public int? baseSizeId { get; set; }
        public string customSize { get; set; }
    }
    public class ProductViewsDetail
    {
        public int id { get; set; }
        public string title { get; set; }
        public Image image { get; set; }
        public string PSDTemplateURL { get; set; }
        public string FabricJSTemplateURL { get; set; }
        public bool? IsCustomersFirstTemplateRequest { get; set; }
        public bool? IsDefaultView { get; set; }
        public TemplateCreationStatus TemplateCreationStatus { get; set; }
        public List<BaseLocation> baseLocations { get; set; }
        public List<SupplierLocation> supplierLocations { get; set; }
        public string code { get; set; }
        public int locations { get; set; }
        public int productParts { get; set; }
        public ProductViewSupplierColor supplierColor { get; set; }
        public ProductViewCategory category { get; set; }
        public bool isApproved { get; set; }

    }
    public class Image
    {
        public int? psMediaContentId { get; set; }
        public string origin { get; set; }
        public Thumbs thumbs { get; set; }
    }
    public class Thumbs
    {
        [JsonProperty("100")]
        public string _100 { get; set; }

        [JsonProperty("300")]
        public string _300 { get; set; }
    }
    public class BaseLocation
    {
        public int id { get; set; }
        public string title { get; set; }
        public string layerName { get; set; }
    }
    public class ProductViewSupplierColor
    {
        public int id { get; set; }
        public string title { get; set; }
        public string hex { get; set; }
    }
}
