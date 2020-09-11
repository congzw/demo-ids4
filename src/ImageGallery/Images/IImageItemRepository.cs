using System.Linq;

namespace ImageGallery.Images
{
    public interface IImageItemRepository
    {
        IQueryable<ImageItem> QueryImages();
    }
}