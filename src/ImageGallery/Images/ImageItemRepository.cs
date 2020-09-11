using System.Collections.Generic;
using System.Linq;

namespace ImageGallery.Images
{
    public class ImageItemRepository : IImageItemRepository
    {
        public ImageItemRepository()
        {
            Items.Add(new ImageItem() { Id = 1, Title = "旺财", Url = "~/img/dogs/wang_cai.jpg", Category = "dog", OwnerId = "Allen"});
            Items.Add(new ImageItem() { Id = 2, Title = "来福", Url = "~/img/dogs/lai_fu.jpg", Category = "dog", OwnerId = "Tom" });
            Items.Add(new ImageItem() { Id = 3, Title = "叮当", Url = "~/img/cats/ding_dang.jpg", Category = "cat", OwnerId = "Tom" });
            Items.Add(new ImageItem() { Id = 4, Title = "阿菲", Url = "~/img/cats/a_fei.jpg", Category = "cat", OwnerId = "Jack" });
        }

        public IList<ImageItem> Items { get; set; } = new List<ImageItem>();

        public IQueryable<ImageItem> QueryImages()
        {
            return Items.AsQueryable();
        }
    }
}