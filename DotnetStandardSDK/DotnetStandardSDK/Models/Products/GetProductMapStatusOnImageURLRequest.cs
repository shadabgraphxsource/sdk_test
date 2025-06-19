using System.Collections.Generic;

namespace DotnetStandardSDK.Models.Products
{
    
    public class GetProductMapStatusOnImageURLRequest
    {
        public string customerName { get; set; }
        public string ColorName { get; set; }
        public string ProductID { get; set; }
        public string ImageURL { get; set; }
        public string Supplier { get; set; }
        public string ClassTypeName { get; set; }

    }

    public class GetProductMapStatusOnImageURLRequestOriginal
    {
        public string CompanyName { get; set; }
        public string ColorName { get; set; }
        public string ProductID { get; set; }
        public string ImageURL { get; set; }
        public string Supplier { get; set; }
        public string ClassTypeName { get; set; }

    }
    public class GetProductMapStatusOnImageURLResponse
    {
        public List<Location> Locations { get; set; }
        public int PartId { get; set; }
        public string ProductPartId { get; set; }
        public int ViewId { get; set; }
        public string MapStatus { get; set; }
    }
    public class Location
    {
        public string layerName { get; set; }
        public int baseLocationID { get; set; }
        public string title { get; set; }
        public bool isDefault { get; set; }
    }
}
