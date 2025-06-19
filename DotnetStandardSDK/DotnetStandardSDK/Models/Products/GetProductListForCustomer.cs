using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetStandardSDK.Models.Products
{
    internal class GetProductListForCustomer
    {
    }
    public class ProductSupplier
    {
        public int id { get; set; }
        public string title { get; set; }
        public int? baseSupplierID { get; set; }
    }

    public class ProductImageThumbs
    {
        public string _100 { get; set; }
        public string _300 { get; set; }
    }

    public class ProductImage
    {
        public int? psMediaContentID { get; set; }
        public string origin { get; set; }
        public ProductImageThumbs thumbs { get; set; }
    }

    public class ProductCategory
    {
        public int productTypeID { get; set; }
        public string productTypeName { get; set; }
    }

    public class ProductBrand
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class ProductGender
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class ProductSupplierCategory
    {
        public int id { get; set; }
        public string title { get; set; }
        public ProductSupplier supplier { get; set; }
    }

    public class ProductItem
    {
        public int id { get; set; }
        public string sku { get; set; }
        public string productID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public ProductSupplier supplier { get; set; }
        public ProductImage image { get; set; }
        public ProductCategory category { get; set; }
        public ProductCategory parentCategory { get; set; }
        public ProductBrand brand { get; set; }
        public ProductGender gender { get; set; }
        public ProductSupplierCategory supplierCategory { get; set; }
        public ProductSupplierCategory supplierParentCategory { get; set; }
        public ProductBrand supplierBrand { get; set; }
        public ProductGender supplierGenderType { get; set; }
        public string externalID { get; set; }
    }

    public class GetProductListForCustomerResponse
    {
        public List<ProductItem> data { get; set; }
        public int totalItems { get; set; }
        public int itemsPerPage { get; set; }
        public int totalPages { get; set; }
    }

    public class ProductSupplierOriginal
    {
        public int id { get; set; }
        public string title { get; set; }
        public int? baseSupplierId { get; set; }
    }

    public class ProductImageThumbsOriginal
    {
        public string _100 { get; set; }
        public string _300 { get; set; }
    }

    public class ProductImageOriginal
    {
        public int? psMediaContentId { get; set; }
        public string origin { get; set; }
        public ProductImageThumbsOriginal thumbs { get; set; }
    }

    public class ProductCategoryOriginal
    {
        public int productTypeId { get; set; }
        public string productTypeName { get; set; }
    }

    public class ProductBrandOriginal
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class ProductGenderOriginal
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class ProductSupplierCategoryOriginal
    {
        public int id { get; set; }
        public string title { get; set; }
        public ProductSupplierOriginal supplier { get; set; }
    }

    public class ProductItemOriginal
    {
        public int id { get; set; }
        public string sku { get; set; }
        public string productId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public ProductSupplierOriginal supplier { get; set; }
        public ProductImageOriginal image { get; set; }
        public ProductCategoryOriginal category { get; set; }
        public ProductCategoryOriginal parentCategory { get; set; }
        public ProductBrandOriginal brand { get; set; }
        public ProductGenderOriginal gender { get; set; }
        public ProductSupplierCategoryOriginal supplierCategory { get; set; }
        public ProductSupplierCategoryOriginal supplierParentCategory { get; set; }
        public ProductBrandOriginal supplierBrand { get; set; }
        public ProductGenderOriginal supplierGenderType { get; set; }
        public string externalId { get; set; }
    }

    public class GetProductListForCustomerResponseOriginal
    {
        public List<ProductItemOriginal> data { get; set; }
        public int totalItems { get; set; }
        public int itemsPerPage { get; set; }
        public int totalPages { get; set; }
    }
}


