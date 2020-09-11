using Microsoft.Extensions.DependencyInjection;

namespace NbSites.Web.Services
{
    public static class ImageGalleryStartup
    {
        public static void AddImageGallery(this IServiceCollection services)
        {
            services.AddSingleton<ImageGalleryConfig>();
            services.AddScoped<IImageGalleryHttpClient, ImageGalleryHttpClient>();
        }
    }
}
