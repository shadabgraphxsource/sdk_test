using DotnetStandardSDK.Models.ProductLine;

namespace DotnetStandardSDK.Tests
{
    /// <summary>
    /// Tests for ProductLineMockups API endpoints.
    /// </summary>
    /// <remarks>
    /// This class contains tests for the ProductLineMockups API endpoints, including retrieving product lines,
    /// creating mockup requests, and checking the status of mockup requests.
    /// </remarks>
    public class ProductLineMockupsTests : BaseTests
    {

        public ProductLineMockupsTests() : base()
        {
        }

        [Theory]
        [InlineData("GXS-PDB Dev Test")]
        //[InlineData("StormTech Performance")]
        public async Task GetAllProductLines_ReturnsSuccess(string customerName)
        {
            var result = await _client.ProductLine.GetAllProductLines(customerName);

            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            //Assert.True(result.Value.productLineID > 0);
            //Assert.False(string.IsNullOrEmpty(result.Value.productLineTitle));
        }

        public static IEnumerable<object[]> GetProductLineMockupRequestExternalData =>
            new List<object[]>
            {
                new object[]
                {
                    new GetProductLineMockupRequestExternalRequest
                    {
                        customerName = "GXS-PDB Dev Test",
                        poNumber = "PO1232435",
                        productLineOrderArtDetails = new List<ProductLineOrderArtDetail>
                        {
                            new ProductLineOrderArtDetail
                            {
                                artURL = "https://graphxserveriodev.blob.core.windows.net/travismathewvirtuals/TravisMathewVirtuals_0406202504_12_247865AM.jpg"
                                // If there is an 'instructions' property, add it here, e.g. instructions = ""
                            }
                        },
                        productLineIDs = new List<string> { "207" },
                        baseColorIDs = new List<string> { "11" }
                    }
                }
            };

        [Theory]
        [MemberData(nameof(GetProductLineMockupRequestExternalData))]
        public async Task GetProductLineMockupRequestExternal_ReturnsSuccess(GetProductLineMockupRequestExternalRequest request)
        {
            var result = await _client.ProductLine.GetProductLineMockupRequestExternal(request);

            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Equal(request.customerName, result.Value.customerName);
            Assert.Equal(request.poNumber, result.Value.poNumber);
        }

        public static IEnumerable<object[]> GetProductLineMockupRequestStatusData =>
            new List<object[]>
            {
            new object[]
            {
                new GetProductLineMockupRequestStatusRequest
                {
                    customerName = "GXS-PDB Dev Test",
                    //productLineMockupOrderNumber = "GRPL-MBP5CJAC" // this mockup order is pending to create on netemb side
                    productLineMockupOrderNumber = "GRPL-LNLB1XLJ"
                }
            }
            };

        [Theory]
        [MemberData(nameof(GetProductLineMockupRequestStatusData))]
        public async Task GetProductLineMockupRequestStatus_ReturnsSuccess(GetProductLineMockupRequestStatusRequest request)
        {
            var result = await _client.ProductLine.GetProductLineMockupRequestStatus(request);

            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Equal(request.customerName, result.Value.customerName);
            Assert.Equal(request.productLineMockupOrderNumber.ToString(), result.Value.productLineMockupOrderNumber);
        }

        public static IEnumerable<object[]> GetProductLineMockupRequestStatusDataForFailure =>
            new List<object[]>
            {
            new object[]
            {
                new GetProductLineMockupRequestStatusRequest
                {
                    customerName = "GXS-PDB Dev Test",
                    productLineMockupOrderNumber = "GRPL-MBP5CJAC" // this mockup order is pending to create on netemb side
                }
            }
            };

        [Theory]
        [MemberData(nameof(GetProductLineMockupRequestStatusDataForFailure))]
        public async Task GetProductLineMockupRequestStatus_ReturnsFailure(GetProductLineMockupRequestStatusRequest request)
        {
            var result = await _client.ProductLine.GetProductLineMockupRequestStatus(request);

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.Errors);
        }
    }
}