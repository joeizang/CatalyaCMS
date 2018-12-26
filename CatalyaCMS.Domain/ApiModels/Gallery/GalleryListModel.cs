using System;
using System.Collections.Generic;
using System.Text;

namespace CatalyaCMS.Domain.ApiModels.Gallery
{
    public class GalleryListModel
    {
        public string GalleryName { get; set; }

        public int NumberOfImages { get; set; }

        public string Description { get; set; }

        public string Creator { get; set; }

        public DateTimeOffset DateCreated { get; set; }

    }
}
