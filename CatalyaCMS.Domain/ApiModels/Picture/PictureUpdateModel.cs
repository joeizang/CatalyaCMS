using System;
using System.Collections.Generic;
using System.Text;

namespace CatalyaCMS.Domain.ApiModels.Picture
{
    public class PictureUpdateModel
    {
        public string PictureTitle { get; set; }

        public string PictureId { get; set; }
        public string Description { get; set; }
        public string PicturePath { get; set; }
        public string GalleryId { get; set; }
    }
}
