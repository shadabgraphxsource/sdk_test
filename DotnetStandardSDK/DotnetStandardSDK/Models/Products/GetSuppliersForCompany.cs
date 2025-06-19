using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetStandardSDK.Models.Products
{
    internal class GetSuppliersForCompany
    {
    }
    public class SupplierOriginal
    {
        public int id { get; set; }
        public string title { get; set; }
        public int? baseSupplierId { get; set; }
    }

    public class Supplier
    {
        public int id { get; set; }
        public string title { get; set; }
        public int? baseSupplierID { get; set; }
    }

    public class GetSuppliersForCompanyResponse
    {
        public List<Supplier> data { get; set; }
    }

    public class GetSuppliersForCompanyResponseOriginal
    {
        public List<SupplierOriginal> data { get; set; }
    }
}
