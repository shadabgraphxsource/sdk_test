using DotnetStandardSDK.Models.Authentication;
using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DotnetStandardSDK.Authentication
{
    internal interface ISecurityClient
    {
        [Post("/api/Security/GetGraphXServerAPIToken")]
        Task<string> GetGraphXServerAPITokenAsync(
            [Header("CompanyName")] string companyName,
            [Header("EndPointsUserName")] string userName,
            [Header("EndPointsPassword")] string password);

        [Post("/api/Security/GenerateTokenByAPISDKKey")]
        Task<string> GenerateTokenByAPISDKKey([Header("APISDKKey")][Required] string APISDKKey);
    }
}
