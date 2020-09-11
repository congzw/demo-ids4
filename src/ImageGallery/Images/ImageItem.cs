namespace ImageGallery.Images
{
    public class ImageItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

        /// <summary>
        /// 所有者
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public string Category { get; set; }
    }
}
