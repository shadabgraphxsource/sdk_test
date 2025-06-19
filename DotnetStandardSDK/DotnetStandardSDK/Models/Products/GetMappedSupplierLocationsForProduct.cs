using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetStandardSDK.Models.Products
{
    internal class GetMappedSupplierLocationsForProduct
    {
    }
    public class SupplierLocationOriginal
    {
        public int? supplierLocationid { get; set; }
        public string supplierLocationName { get; set; }
        public int baseLocationId { get; set; }
        public string baseLocationName { get; set; }
        public bool isDefault { get; set; }
    }

    public class SupplierLocation
    {
        public int? supplierLocationID { get; set; }
        public string supplierLocationName { get; set; }
        public int baseLocationID { get; set; }
        public string baseLocationName { get; set; }
        public bool isDefault { get; set; }
    }

    public class ProductPartViewOriginal
    {
        public int productViewId { get; set; }
        public bool isDefeault { get; set; }
        public List<SupplierLocationOriginal> locations { get; set; }
    }

    public class ProductPartView
    {
        public int productViewID { get; set; }
        public bool isDefeault { get; set; }
        public List<SupplierLocation> locations { get; set; }
    }

    public class ProductPartMappedLocationOriginal
    {
        public int productPartId { get; set; }
        public List<ProductPartViewOriginal> productViews { get; set; }
    }

    public class ProductPartMappedLocation
    {
        public int productPartID { get; set; }
        public List<ProductPartView> productViews { get; set; }
    }

    public class GetMappedSupplierLocationsForProductResponseOriginal
    {
        public List<ProductPartMappedLocationOriginal> data { get; set; }
    }

    public class GetMappedSupplierLocationsForProductResponse
    {
        public List<ProductPartMappedLocation> data { get; set; }
    }


}
