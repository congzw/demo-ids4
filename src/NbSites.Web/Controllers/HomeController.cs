using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using NbSites.Web.Services;
using Newtonsoft.Json;

namespace NbSites.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Images([FromServices]IImageGalleryHttpClient imageGalleryHttpClient, [FromServices] ImageGalleryConfig config)
        {
            //for test
            await WriteOutIdentityInformation();

            var imagesViewModel = new ImagesViewModel();

            // call the API
            var httpClient = await imageGalleryHttpClient.GetClient();
            var response = await httpClient.GetAsync("Api/Image/GetImages").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var imagesAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var imageItems = JsonConvert.DeserializeObject<IList<ImageItem>>(imagesAsString).ToList();
                foreach (var imageItem in imageItems)
                {
                    imageItem.Url = config.BaseUri + imageItem.Url;
                }
                imagesViewModel.Images = imageItems;
            }
            return View(imagesViewModel);
        }


        public async Task WriteOutIdentityInformation()
        {
            // get the saved identity token
            var identityToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            // write it out
            Debug.WriteLine($"Identity token: {identityToken}");

            // write out the user claims
            foreach (var claim in User.Claims)
            {
                Debug.WriteLine($"Claim type: {claim.Type} - Claim value: {claim.Value}");
            }
        }
    }

    public class ImagesViewModel
    {
        public IEnumerable<ImageItem> Images { get; set; } = new List<ImageItem>();
    }

    public class ImageItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string OwnerId { get; set; }
        public string Category { get; set; }
    }
}
