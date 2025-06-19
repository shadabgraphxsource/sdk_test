using DotnetStandardSDK.Models.Mockups;
using DotnetStandardSDK.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetStandardSDK.Tests
{
    public class MockupsTests : BaseTests
    {
        #region [Parameterized Data]
        // Parameterized data for GetProductMockupRequestExternal
        public static IEnumerable<object[]> ProductMockupRequestExternalData =>
            new List<object[]>
            {
                new object[]
                {
                    new GetProductMockupRequestExternalRequest
                    {
                        customerName = "GXS-PDB Dev Test",
                        mockupRequestType = "Standard",
                        mockupRequestOrderProduct = new List<MockupRequestOrderProduct>
                        {
                            new MockupRequestOrderProduct
                            {
                                supplierID = "6",
                                productPartID = "1-W0-Hoodies-WH",
                                mockupRequestOrderProductLocation = new List<MockupRequestOrderProductLocation>
                                {
                                    new MockupRequestOrderProductLocation
                                    {
                                        locationName = "Right Chest",
                                        artURL = "https://graphxserveriodemo.blob.core.windows.net/graphxserverio/nationalfootballleaguelogosvg_1707202305_53_255612AM.png",
                                        instructions = "test order"
                                    }
                                }
                            }
                        }
                    }
                }
            };

        // Parameterized data for GetProductMockupRequestStatus
        public static IEnumerable<object[]> ProductMockupRequestStatusData =>
            new List<object[]>
            {
                new object[]
                {
                    new GetProductMockupRequestStatusRequest
                    {
                        customerName = "GXS-PDB Dev Test",
                        mockupOrderNumber = "MCKP-MBG8FC25"
                    }
                }
            };

        // Parameterized data for CreateMockupOrderForMultipleViews
        public static IEnumerable<object[]> CreateMockupOrderForMultipleViewsData =>
            new List<object[]>
            {
                new object[]
                {
                    new CreateMockupOrderForMultipleViewsRequest
                    {
                        customerName = "StormTech Performance",
                        poNumber = "PO123456",
                        mockupRequestType = "Standard",
                        mockupOrderProduct = new MockupOrderProduct
                        {
                            productPartID = "1HR0001077",
                            supplierID = 52,
                            mockupRequestOrderProductViews = new List<MockupRequestOrderProductView>
                            {
                                new MockupRequestOrderProductView
                                {
                                    productViewID = 1799,
                                    mockupRequestOrderProductViewLocations = new List<MockupRequestOrderProductViewLocation>
                                    {
                                        new MockupRequestOrderProductViewLocation
                                        {
                                            locationName = "Left Chest",
                                            artURL = "https://graphxserveriodemo.blob.core.windows.net/artcust1/Art_Cust1_0111202306_26_179364AM.png",
                                            instructions = ""
                                        },
                                        new MockupRequestOrderProductViewLocation
                                        {
                                            locationName = "LEFT BOTTOM FRONT",
                                            artURL = "https://graphxserveriodemo.blob.core.windows.net/artcust1/Art_Cust1_0111202306_26_179364AM.png",
                                            instructions = ""
                                        }
                                    }
                                },
                                new MockupRequestOrderProductView
                                {
                                    productViewID = 2507,
                                    mockupRequestOrderProductViewLocations = new List<MockupRequestOrderProductViewLocation>
                                    {
                                        new MockupRequestOrderProductViewLocation
                                        {
                                            locationName = "Upper Back",
                                            artURL = "https://graphxserveriodemo.blob.core.windows.net/artcust1/Art_Cust1_0111202306_26_179364AM.png",
                                            instructions = ""
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

        // Parameterized data for GetStatusForMultipleViewMockup
        public static IEnumerable<object[]> GetStatusForMultipleViewMockupData =>
            new List<object[]>
            {
                new object[]
                {
                    new GetStatusForMultipleViewMockupRequest
                    {
                        customerName = "StormTech Performance",
                        mockupOrderNumber = "MCKP-MBG9LHCQ",
                        regenerateProductViewID = 0
                    }
                }
            };
        #endregion [Parameterized Data]
        public MockupsTests() : base()
        {
        }

        [Theory]
        [MemberData(nameof(ProductMockupRequestExternalData))]
        public async Task GetProductMockupRequestExternal_ReturnsResponse(GetProductMockupRequestExternalRequest request)
        {
            var response = await _client.Mockups.GetProductMockupRequestExternal(request);
            //pDBOrderID = response.orderID;
            //pDBOutsourcedOrderID = response.outsourcedMockupOrderID;
            Assert.NotNull(response);
        }

        [Theory]
        [MemberData(nameof(ProductMockupRequestStatusData))]
        public async Task GetProductMockupRequestStatus_ReturnsResponse(GetProductMockupRequestStatusRequest request)
        {
            var response = await _client.Mockups.GetProductMockupRequestStatus(request);
            Assert.NotNull(response);
        }

        [Theory]
        [MemberData(nameof(CreateMockupOrderForMultipleViewsData))]
        public async Task CreateMockupOrderForMultipleViews_ReturnsResponse(CreateMockupOrderForMultipleViewsRequest request)
        {
            var response = await _client1.Mockups.CreateMockupOrderForMultipleViews(request);
            //stormTechOrderID = response.orderID;
            //stormTechOutsourcedOrderID = response.outsourcedMockupOrderID;
            Assert.NotNull(response);
        }

        [Theory]
        [MemberData(nameof(GetStatusForMultipleViewMockupData))]
        public async Task GetStatusForMultipleViewMockup_ReturnsResponse(GetStatusForMultipleViewMockupRequest request)
        {
            var response = await _client1.Mockups.GetStatusForMultipleViewMockup(request);
            Assert.NotNull(response);
        }
    }


    public class BaseTests
    {
        internal readonly IGraphXClient _client;
        internal readonly IGraphXClient _client1;
        internal int pDBOrderID = 0;
        internal int pDBOutsourcedOrderID = 0;
        internal int stormTechOrderID = 0;
        internal int stormTechOutsourcedOrderID = 0;
        public BaseTests()
        {
            var services = new ServiceCollection();
            services.AddGraphXClientAsync(options =>
            {
                options.Environment = EnvironmentType.Development;
                options.Key = "l7b6WYxINeeWLG4STmfSzR6iAKOSl3rs9mb7XImjgyE=";
            }).GetAwaiter().GetResult();
            var provider = services.BuildServiceProvider();
            _client = provider.GetRequiredService<IGraphXClient>();

            var services1 = new ServiceCollection();
            services1.AddGraphXClientAsync(options =>
            {
                options.Environment = EnvironmentType.Development;
                options.Key = "Gp8dJ56Tq20rFfQJIkCC4A6a60+mPxLSFgRrqAl29AM=";
            }).GetAwaiter().GetResult();
            var provider1 = services1.BuildServiceProvider();
            _client1 = provider1.GetRequiredService<IGraphXClient>();
        }
    }
}