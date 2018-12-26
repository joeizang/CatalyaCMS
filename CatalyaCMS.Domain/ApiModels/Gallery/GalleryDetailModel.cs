using System;
using System.Collections.Generic;
using System.Text;

namespace CatalyaCMS.Domain.ApiModels.Gallery
{
    public class GalleryDetailModel
    {
        public string GalleryName { get; set; }
        public int PicturesInGallery { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
