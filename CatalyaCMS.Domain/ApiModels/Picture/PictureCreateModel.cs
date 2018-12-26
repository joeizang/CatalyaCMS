namespace CatalyaCMS.Domain.ApiModels.Picture
{
    public class PictureCreateModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string PicturePath { get; set; }

        public string GalleryName { get; set; }

        public string OwnerId { get; set; }
    }
}
