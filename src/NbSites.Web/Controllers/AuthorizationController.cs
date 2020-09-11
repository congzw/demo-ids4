using System;
using System.Diagnostics;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace NbSites.Web.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
        public async Task Logout()
        {
            // Clears the  local cookie ("Cookies" must match name from scheme)
            await HttpContext.SignOutAsync("Cookies");
            await HttpContext.SignOutAsync("oidc");
        }

        //public async Task Logout()
        //{
        //    //-MyIDP => http://localhost:8309
        //    //-ImageGallery => http://localhost:2047
        //    //-NbSites.Web => http://localhost:12060
        //    // get the metadata
        //    var discoveryClient = new DiscoveryClient("http://localhost:8309");
        //    var metaDataResponse = await discoveryClient.GetAsync();

        //    // create a TokenRevocationClient
        //    var revocationClient = new TokenRevocationClient(
        //        metaDataResponse.RevocationEndpoint,
        //        "imagegalleryclient",
        //        "secret");

        //    // get the access token to revoke 
        //    var accessToken = await HttpContext
        //      .GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

        //    if (!string.IsNullOrWhiteSpace(accessToken))
        //    {
        //        var revokeAccessTokenResponse =
        //            await revocationClient.RevokeAccessTokenAsync(accessToken);

        //        if (revokeAccessTokenResponse.IsError)
        //        {
        //            throw new Exception("Problem encountered while revoking the access token."
        //                , revokeAccessTokenResponse.Exception);
        //        }
        //    }

        //    // revoke the refresh token as well
        //    var refreshToken = await HttpContext
        //     .GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

        //    if (!string.IsNullOrWhiteSpace(refreshToken))
        //    {
        //        var revokeRefreshTokenResponse =
        //            await revocationClient.RevokeRefreshTokenAsync(refreshToken);

        //        if (revokeRefreshTokenResponse.IsError)
        //        {
        //            throw new Exception("Problem encountered while revoking the refresh token."
        //                , revokeRefreshTokenResponse.Exception);
        //        }
        //    }


        //    // Clears the  local cookie ("Cookies" must match name from scheme)
        //    await HttpContext.SignOutAsync("Cookies");
        //    await HttpContext.SignOutAsync("oidc");
        //}
    }
}
