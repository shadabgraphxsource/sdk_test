using DotnetStandardSDK.Models.Products;

namespace DotnetStandardSDK.Tests
{
    public class ProductsTests : BaseTests
    {
        #region [Parameterized Data]

        public static IEnumerable<object[]> GetProductListForCustomerData =>
            new List<object[]>
            {
                new object[] { "GXS-PDB Dev Test", 2 }
            };

        public static IEnumerable<object[]> GetProductPartsByProductIDData =>
            new List<object[]>
            {
                new object[]
                {
                    new GetProductPartsByProductIDRequest
                    {
                        customerName = "GXS-PDB Dev Test",
                        productID = "1-M0-TShirts"
                    }
                }
            };

        public static IEnumerable<object[]> GetProductViewsData =>
            new List<object[]>
            {
                new object[] { "GXS-PDB Dev Test", "1-W0-Hoodies-WH", 6 }
            };

        public static IEnumerable<object[]> GetMappedSupplierLocationsForProductData =>
            new List<object[]>
            {
                new object[] { "GXS-PDB Dev Test", "1-M0-TShirts", 6 }
            };

        public static IEnumerable<object[]> GetSuppliersForCompanyData =>
            new List<object[]>
            {
                new object[] { "GXS-PDB Dev Test" }
            };

        public static IEnumerable<object[]> GetProductPartDetailsData =>
            new List<object[]>
            {
                new object[] { "GXS-PDB Dev Test", "1-W0-Hoodies-WH", 6 }
            };

        public static IEnumerable<object[]> GetProductPartIDOnStyleNumberData =>
            new List<object[]>
            {
                new object[]
                {
                    new ProductStyleDetails
                    {
                        styleNumber = "25528",
                        productColor = "Stonewash",
                        sizes = new List<string> { "XS", "SM", "MD" },
                        supplierID = 58,
                        productImage = "https://dev.pdb.graphxserver.io/Media/origin/af0/af0f80b7fb35bb815b2a18f2984171e4.webp"
                    }
                }
            };

        public static IEnumerable<object[]> GetProductMapStatusOnImageURLData =>
            new List<object[]>
            {
                new object[]
                {
                    new GetProductMapStatusOnImageURLRequest
                    {
                        customerName = "GXS-PDB Dev Test",
                        ImageURL = "https://cdnm.sanmar.com/imglib/mresjpg/2012/f14/548533_GameRoyal_Flat_Back.jpg",
                        Supplier = "Sanmar",
                        ColorName = "Game Royal/Wht",
                        ProductID = "548533",
                        ClassTypeName = "Rear"
                    }
                }
            };

        public static IEnumerable<object[]> GetAllProductColorsData =>
            new List<object[]>
            {
                new object[] { "GXS-PDB Dev Test" }
            };

        #endregion [Parameterized Data]

        public ProductsTests() : base()
        {
        }

        [Theory]
        [MemberData(nameof(GetProductListForCustomerData))]
        public async Task GetProductListForCustomer_Success(string customerName, int page)
        {
            var response = await _client.Products.GetProductListForCustomer(customerName, page);
            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Value);
        }

        [Fact]
        public async Task GetProductListForCustomer_Failure()
        {
            // Use invalid data or mock the client to return failure
            var response = await _client.Products.GetProductListForCustomer("InvalidCustomer", -1);
            Assert.False(response.IsSuccess);
            Assert.NotNull(response.Errors);
        }

        [Theory]
        [MemberData(nameof(GetProductPartsByProductIDData))]
        public async Task GetProductPartsByProductID_Success(GetProductPartsByProductIDRequest request)
        {
            var response = await _client.Products.GetProductPartsByProductID(request);
            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Value);
        }

        [Fact]
        public async Task GetProductPartsByProductID_Failure()
        {
            var request = new GetProductPartsByProductIDRequest { customerName = "", productID = "" };
            var response = await _client.Products.GetProductPartsByProductID(request);
            Assert.False(response.IsSuccess);
            Assert.NotNull(response.Errors);
        }

        [Theory]
        [MemberData(nameof(GetProductViewsData))]
        public async Task GetProductViews_Success(string companyName, string productPartId, int supplierId)
        {
            var response = await _client.Products.GetProductViews(companyName, productPartId, supplierId);
            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Value);
        }

        [Fact]
        public async Task GetProductViews_Failure()
        {
            var response = await _client.Products.GetProductViews("", "", -1);
            Assert.False(response.IsSuccess);
            Assert.NotNull(response.Errors);
        }

        [Theory]
        [MemberData(nameof(GetMappedSupplierLocationsForProductData))]
        public async Task GetMappedSupplierLocationsForProduct_Success(string companyName, string productId, int supplierId)
        {
            var response = await _client.Products.GetMappedSupplierLocationsForProduct(companyName, productId, supplierId);
            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Value);
        }

        [Fact]
        public async Task GetMappedSupplierLocationsForProduct_Failure()
        {
            var response = await _client.Products.GetMappedSupplierLocationsForProduct("", "", -1);
            Assert.False(response.IsSuccess);
            Assert.NotNull(response.Errors);
        }

        [Theory]
        [MemberData(nameof(GetSuppliersForCompanyData))]
        public async Task GetSuppliersForCompany_Success(string companyName)
        {
            var response = await _client.Products.GetSuppliersForCompany(companyName);
            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Value);
        }

        [Fact]
        public async Task GetSuppliersForCompany_Failure()
        {
            var response = await _client.Products.GetSuppliersForCompany("");
            Assert.False(response.IsSuccess);
            Assert.NotNull(response.Errors);
        }

        [Theory]
        [MemberData(nameof(GetProductPartDetailsData))]
        public async Task GetProductPartDetails_Success(string companyName, string productPartId, int supplierId)
        {
            var response = await _client.Products.GetProductPartDetails(companyName, productPartId, supplierId);
            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Value);
        }

        [Fact]
        public async Task GetProductPartDetails_Failure()
        {
            var response = await _client.Products.GetProductPartDetails("", "", -1);
            Assert.False(response.IsSuccess);
            Assert.NotNull(response.Errors);
        }

        [Theory]
        [MemberData(nameof(GetProductPartIDOnStyleNumberData))]
        public async Task GetProductPartIDOnStyleNumber_Success(ProductStyleDetails productStyleDetails)
        {
            var response = await _client.Products.GetProductPartIDOnStyleNumber(productStyleDetails);
            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Value);
        }

        [Fact]
        public async Task GetProductPartIDOnStyleNumber_Failure()
        {
            var request = new ProductStyleDetails();
            var response = await _client.Products.GetProductPartIDOnStyleNumber(request);
            Assert.False(response.IsSuccess);
            Assert.NotNull(response.Errors);
        }

        [Theory]
        [MemberData(nameof(GetProductMapStatusOnImageURLData))]
        public async Task GetProductMapStatusOnImageURL_Success(GetProductMapStatusOnImageURLRequest request)
        {
            var response = await _client.Products.GetProductMapStatusOnImageURL(request);
            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Value);
        }

        [Fact]
        public async Task GetProductMapStatusOnImageURL_Failure()
        {
            var request = new GetProductMapStatusOnImageURLRequest();
            var response = await _client.Products.GetProductMapStatusOnImageURL(request);
            Assert.False(response.IsSuccess);
            Assert.NotNull(response.Errors);
        }

        [Theory]
        [MemberData(nameof(GetAllProductColorsData))]
        public async Task GetAllProductColors_Success(string customerName)
        {
            var response = await _client.Products.GetAllProductColors(customerName);
            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Value);
        }

        [Fact]
        public async Task GetAllProductColors_Failure()
        {
            var response = await _client.Products.GetAllProductColors("");
            Assert.False(response.IsSuccess);
            Assert.NotNull(response.Errors);
        }
    }
}