using DotnetStandardSDK;
using DotnetStandardSDK.Models.Mockups;
using DotnetStandardSDK.Utilities;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

// Fix for CS1729: 'GraphXClient' does not contain a constructor that takes 1 arguments
// Based on the provided type signature, the GraphXClient class does not have a constructor that accepts a single argument.
// Instead, it seems to require a factory method to create an instance. Adjusting the code accordingly.

#region [Test : Object Creation]
//IGraphXClient graphXClient = new GraphXClient().Build("http://localhost:52510", "GraphxServerIO", "superadmin@graphxsource.com", "Pass123");
//IGraphXClient graphXClient = new GraphXClient().Build("http://localhost:52510", "GXS-PDB Dev Test", "gxspdbdevtest1@abc.com", "11111111");
//IGraphXClient graphXClient1 = new GraphXClient().Build("http://localhost:52510", "StormTech Performance", "stormtech@abcd.com", "Test@123");
//IGraphXClient graphXClient1 = new GraphXClient().Build("http://localhost:52510", "Art_Cust1", "art_cust1@gmail.com", "Pass123");
#endregion

#region [Test : GetGraphXServerAPITokenAsync]
//var token = await GraphXClientFactory.Security.GetGraphXServerAPITokenAsync("GraphxServerIO", "superadmin@graphxsource.com", "Pass123");
//Console.WriteLine(token);
#endregion

#region [Test : GetProductMockupRequestExternal]
IGraphXClient1 graphXClient = new GraphXClient1().Build("http://localhost:52510", "GXS-PDB Dev Test", "gxspdbdevtest1@abc.com", "11111111");
GetProductMockupRequestExternalRequest productMockupRequestExternalRequest = new GetProductMockupRequestExternalRequest
{
    customerName  = "GXS-PDB Dev Test",
    mockupRequestType = "Standard",
    //PONumber = "PO123456",
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
                    instructions = ""
                }
            }
        }
    }
};

//var getProductMockupRequestExternalResponse = await GraphXClientFactory.Mockups.GetProductMockupRequestExternal(productMockupRequestExternalRequest);
//Console.WriteLine(getProductMockupRequestExternalResponse);
// MockupRequest Number - MCKP-MBG8FC25, 
#endregion

#region [Test : GetProductMockupRequestStatus]
GetProductMockupRequestStatusRequest productMockupRequestStatusRequest = new GetProductMockupRequestStatusRequest
{
    customerName = "GXS-PDB Dev Test",
    mockupOrderNumber = "MCKP-MBG8FC25"
};

//var getProductMockupRequestStatusResponse = await GraphXClientFactory.Mockups.GetProductMockupRequestStatus(productMockupRequestStatusRequest);
//Console.WriteLine(getProductMockupRequestStatusResponse);
// MockupRequest Number - MCKP-MBG8FC25, 
#endregion

#region [Test : CreateMockupOrderForMultipleViews]
new GraphXClient1().Build("http://localhost:52510", "StormTech Performance", "stormtech@abcd.com", "Test@123");
CreateMockupOrderForMultipleViewsRequest createMockupOrderForMultipleViewsRequest = new CreateMockupOrderForMultipleViewsRequest
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
};

//var createMockupOrderForMultipleViewsRequestResponse = await GraphXClientFactory.Mockups.CreateMockupOrderForMultipleViews(createMockupOrderForMultipleViewsRequest);
//Console.WriteLine(createMockupOrderForMultipleViewsRequestResponse);
// MockupRequest Number - MCKP-MBG9LHCQ,  
#endregion

#region [Test : GetStatusForMultipleViewMockup]
new GraphXClient1().Build("http://localhost:52510", "StormTech Performance", "stormtech@abcd.com", "Test@123");
GetStatusForMultipleViewMockupRequest getStatusForMultipleViewMockupRequest = new GetStatusForMultipleViewMockupRequest
{
    customerName = "StormTech Performance",
    mockupOrderNumber = "MCKP-MBG9LHCQ",
    regenerateProductViewID = 0
};

//var getStatusForMultipleViewMockupResponse = await GraphXClientFactory.Mockups.GetStatusForMultipleViewMockup(getStatusForMultipleViewMockupRequest);
//Console.WriteLine(getStatusForMultipleViewMockupResponse);
// MockupRequest Number - MCKP-MBG9LHCQ,
#endregion

#region [Test : New way to register SDK client object]

#region [ Option - 1 - to register ]
var services = new ServiceCollection();
await services.AddGraphXClientAsync(options =>
{
    options.Environment = EnvironmentType.Development;
    options.Key = "l7b6WYxINeeWLG4STmfSzR6iAKOSl3rs9mb7XImjgyE=";
});
var provider = services.BuildServiceProvider();
var graphXClient1 = provider.GetRequiredService<IGraphXClient>();
#endregion

#region [ Option - 2 - to register ]
//IGraphXClient graphXClient1 = await GraphXClient.BuildAsync(new GraphXClientOptions
//{
//    options.Environment = EnvironmentType.Development;
//    options.Key = "l7b6WYxINeeWLG4STmfSzR6iAKOSl3rs9mb7XImjgyE=";
//});
    #endregion

    #endregion

#region [Test : GetProductMockupRequestExternal-1]
    GetProductMockupRequestExternalRequest productMockupRequestExternalRequest1 = new GetProductMockupRequestExternalRequest
{
    customerName = "GXS-PDB Dev Test",
    mockupRequestType = "Standard",
    //PONumber = "PO123456",
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
                    instructions = ""
                }
            }
        }
    }
};
var getProductMockupRequestExternalResponse1 = await graphXClient1.Mockups.GetProductMockupRequestExternal(productMockupRequestExternalRequest1);
Console.WriteLine(getProductMockupRequestExternalResponse1);
// MockupRequest Number - MCKP-MBG8FC25, 
#endregion
