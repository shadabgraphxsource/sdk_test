using DotnetStandardSDK.Models.Alerts;

namespace DotnetStandardSDK.Tests
{
    public class AlertsTests : BaseTests
    {
        #region [Parameterized Data]

        #region [Parameterized data for GET]
        /// Parameterized data for GET methods (MockupOrder)
        public static IEnumerable<object[]> AlertGetMockupOrderTestData =>
            new List<object[]>
            {
                new object[] { "GXS-PDB Dev Test", 119294 },
                //new object[] { "StormTech Performance", 118500 }
            };

        // Parameterized data for GET methods (TemplateOrder)
        public static IEnumerable<object[]> AlertGetTemplateOrderTestData =>
            new List<object[]>
            {
                new object[] { "GXS-PDB Dev Test", 118500 },
                //new object[] { "StormTech Performance", 118501 }
            };

        // Parameterized data for GET methods (ArtOrder)
        public static IEnumerable<object[]> AlertGetArtOrderTestData =>
            new List<object[]>
            {
                new object[] { "GXS-PDB Dev Test", 119293 },
                //new object[] { "StormTech Performance", 119294 }
            };

        #endregion

        #region [Parameterized data for POST]
        // Parameterized data for POST methods (MockupOrder)
        public static IEnumerable<object[]> AlertPostMockupOrderTestData =>
            new List<object[]>
            {
                new object[]
                {
                    new PostAlertsForOrderRequest
                    {
                        customerName = "GXS-PDB Dev Test",
                        outsourcedMockupOrderId = 119294,
                        message = "This is a test alert from SDK.",
                        subject = "Test Alert from SDK"
                    }
                }
            };

        // Parameterized data for POST methods (TemplateOrder)
        public static IEnumerable<object[]> AlertPostTemplateOrderTestData =>
            new List<object[]>
            {
                new object[]
                {
                    new PostAlertsForOrderRequest
                    {
                        customerName = "GXS-PDB Dev Test",
                        outsourcedProductTemplateOrderId = 118500,
                        message = "This is a test alert for template order from SDK.",
                        subject = "Test Template Alert from SDK"
                    }
                }
            };

        // Parameterized data for POST methods (ArtOrder)
        public static IEnumerable<object[]> AlertPostArtOrderTestData =>
            new List<object[]>
            {
                new object[]
                {
                    new PostAlertsForOrderRequest
                    {
                        customerName = "GXS-PDB Dev Test",
                        outsourcedArtOrderId = 119293,
                        message = "This is a test alert for art order from SDK.",
                        subject = "Test Art Alert from SDK"
                    }
                }
            };
        #endregion

        #endregion [Parameterized Data]
        public AlertsTests() : base()
        {

        }

        [Theory]
        [MemberData(nameof(AlertPostMockupOrderTestData))]
        public async Task PostAlertsForMockupOrder_ReturnsResponse(PostAlertsForOrderRequest request)
        {
            var response = await _client.Alerts.PostAlertsForMockupOrder(request);
            Assert.NotNull(response);
        }

        [Theory]
        [MemberData(nameof(AlertPostTemplateOrderTestData))]
        public async Task PostAlertsForTemplateOrder_ReturnsResponse(PostAlertsForOrderRequest request)
        {
            var response = await _client.Alerts.PostAlertsForTemplateOrder(request);
            Assert.NotNull(response);
        }

        [Theory]
        [MemberData(nameof(AlertPostArtOrderTestData))]
        public async Task PostAlertsForArtOrder_ReturnsResponse(PostAlertsForOrderRequest request)
        {
            var response = await _client.Alerts.PostAlertsForArtOrder(request);
            Assert.NotNull(response);
        }

        [Theory]
        [MemberData(nameof(AlertGetMockupOrderTestData))]
        public async Task GetAlertsForMockupOrder_ReturnsResponse(string customerName, int outsourcedMockupOrderId)
        {
            var response = await _client.Alerts.GetAlertsForMockupOrder(customerName, outsourcedMockupOrderId);
            Assert.NotNull(response);
        }

        [Theory]
        [MemberData(nameof(AlertGetTemplateOrderTestData))]
        public async Task GetAlertsForTemplateOrder_ReturnsResponse(string customerName, int outsourcedProductTemplateOrderId)
        {
            var response = await _client.Alerts.GetAlertsForTemplateOrder(customerName, outsourcedProductTemplateOrderId);
            Assert.NotNull(response);
        }

        [Theory]
        [MemberData(nameof(AlertGetArtOrderTestData))]
        public async Task GetAlertsForArtOrder_ReturnsResponse(string customerName, int outsourcedArtOrderId)
        {
            var response = await _client.Alerts.GetAlertsForArtOrder(customerName, outsourcedArtOrderId);
            Assert.NotNull(response);
        }
    }
}