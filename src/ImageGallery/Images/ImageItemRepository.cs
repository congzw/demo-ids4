using System.Collections.Generic;
using System.Linq;

namespace ImageGallery.Images
{
    public class ImageItemRepository : IImageItemRepository
    {
        public ImageItemRepository()
        {
            Items.Add(new ImageItem() { Id = 1, Title = "旺财", Url = "~/img/dogs/wang_cai.jpg" });
            Items.Add(new ImageItem() { Id = 2, Title = "来福", Url = "~/img/dogs/lai_fu.jpg" });
        }

        public IList<ImageItem> Items { get; set; } = new List<ImageItem>();

        public IQueryable<ImageItem> QueryImages()
        {
            return Items.AsQueryable();
        }
    }
}