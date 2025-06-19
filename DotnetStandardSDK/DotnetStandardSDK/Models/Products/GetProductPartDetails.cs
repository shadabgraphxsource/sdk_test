using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetStandardSDK.Models.Products.GetProductPartDetails
{
    internal class GetProductPartDetails
    {
    }
    public class ProductSupplier
    {
        public int id { get; set; }
        public string title { get; set; }
        public int? baseSupplierId { get; set; }
    }

    public class ProductImageThumbs
    {
        public string _100 { get; set; }
        public string _300 { get; set; }
    }

    public class ProductImage
    {
        public int? psMediaContentId { get; set; }
        public string origin { get; set; }
        public ProductImageThumbs thumbs { get; set; }
    }

    public class ProductCategory
    {
        public int productTypeId { get; set; }
        public string productTypeName { get; set; }
    }

    public class ProductGender
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class ProductBaseLocation
    {
        public int id { get; set; }
        public string title { get; set; }
        public string layerName { get; set; }
    }

    public class ProductBrand
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class Product
    {
        public int id { get; set; }
        public string sku { get; set; }
        public string productId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public ProductSupplier supplier { get; set; }
        public ProductImage image { get; set; }
        public ProductCategory category { get; set; }
        public ProductCategory parentCategory { get; set; }
        public ProductBrand brand { get; set; }
        public ProductGender gender { get; set; }
        public object supplierCategory { get; set; }
        public object supplierParentCategory { get; set; }
        public object supplierBrand { get; set; }
        public object supplierGenderType { get; set; }
        public string externalId { get; set; }
    }

    public class SupplierColor
    {
        public int id { get; set; }
        public string colorName { get; set; }
        public string hex { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public object baseColor { get; set; }
    }

    public class BaseColor
    {
        public int id { get; set; }
        public string title { get; set; }
        public string hex { get; set; }
        public string colorName { get; set; }
    }

    public class ProductPartIDSelected
    {
        public int id { get; set; }
        public string productPartId { get; set; }
        public ProductImage image { get; set; }
        public int psMediaContentId { get; set; }
        public SupplierColor supplierColor { get; set; }
        public List<SupplierColor> supplierColors { get; set; }
        public string externalId { get; set; }
        public BaseColor baseColor { get; set; }
        public object apparelSize { get; set; }
        public object supplierApparelSize { get; set; }
        public List<object> supplierLocations { get; set; }
        public List<ProductBaseLocation> baseLocations { get; set; }
    }

    public class TemplateCreationStatus
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class ProductViewDetail
    {
        public int id { get; set; }
        public string title { get; set; }
        public ProductImage image { get; set; }
        public string psdTemplateURL { get; set; }
        public string fabricJSTemplateURL { get; set; }
        public bool isCustomersFirstTemplateRequest { get; set; }
        public bool isDefaultView { get; set; }
        public TemplateCreationStatus templateCreationStatus { get; set; }
        public List<ProductBaseLocation> baseLocations { get; set; }
        public List<object> supplierLocations { get; set; }
        public string code { get; set; }
        public int locations { get; set; }
        public int productParts { get; set; }
        public SupplierColor supplierColor { get; set; }
        public ProductViewDetailCategory category { get; set; }
        public bool isApproved { get; set; }
    }

    public class ProductViewDetailCategory
    {
        public int id { get; set; }
        public string title { get; set; }
        public string code { get; set; }
    }

    public class GetProductPartDetailsResponse
    {
        public Product product { get; set; }
        public List<BaseApparelSize> baseApparelSize { get; set; }
        public List<SupplierApparelSize> supplierApparelSize { get; set; }
        public ProductPartIDSelected productPartIDSelected { get; set; }
        public List<ProductViewDetail> productViewsDetail { get; set; }
    }
}

