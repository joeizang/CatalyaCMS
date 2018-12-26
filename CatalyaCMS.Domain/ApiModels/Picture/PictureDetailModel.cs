using System;
using System.Collections.Generic;
using System.Text;

namespace CatalyaCMS.Domain.ApiModels.Picture
{
    public class PictureDetailModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string PicturePath { get; set; }

        public string GalleryId { get; set; }

        public List<string> Tags { get; set; }
    }
}
