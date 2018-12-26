using System;
using System.Collections.Generic;
using System.Text;

namespace CatalyaCMS.Domain.ApiModels.Picture
{
    public class PictureListModel
    {
        public string PictureTitle { get; set; }

        public string Description { get; set; }

        public string ThumbNail { get; set; }

        public string Id { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
    }
}
