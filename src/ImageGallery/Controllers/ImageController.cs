using System.Collections.Generic;
using System.Linq;
using ImageGallery.Images;
using Microsoft.AspNetCore.Mvc;

namespace ImageGallery.Controllers
{
    [Route("Api/Image")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageItemRepository _repository;

        public ImageController(IImageItemRepository repository)
        {
            _repository = repository;
        }

        [Route("GetImages")]
        [HttpGet]
        public IList<ImageItem> GetImages()
        {
            var imageItems = _repository.QueryImages().ToList();
            foreach (var imageItem in imageItems)
            {
                imageItem.Url = Url.Content(imageItem.Url);
            }
            return imageItems;
        }
    }
}
