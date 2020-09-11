using Microsoft.Extensions.DependencyInjection;

namespace ImageGallery.Images
{
    public static class ImageStartup
    {
        public static void AddImages(this IServiceCollection services)
        {
            services.AddSingleton<IImageItemRepository, ImageItemRepository>();
        }
    }
}
