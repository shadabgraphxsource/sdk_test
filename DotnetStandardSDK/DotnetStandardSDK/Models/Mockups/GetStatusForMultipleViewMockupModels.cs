using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DotnetStandardSDK.Models.Mockups
{
    internal class GetStatusForMultipleViewMockupModels
    {
    }

    #region [request]
    public class GetStatusForMultipleViewMockupRequest
    {
        public string customerName { get; set; }
        public string mockupOrderNumber { get; set; }
        public int regenerateProductViewID { get; set; }
    }
    #endregion
}
