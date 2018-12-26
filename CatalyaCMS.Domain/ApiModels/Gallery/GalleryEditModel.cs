using System;
using System.Collections.Generic;
using System.Text;

namespace CatalyaCMS.Domain.ApiModels.Gallery
{
    public class GalleryEditModel
    {
        public string GalleryName { get; set; }

        public string Description { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public string Id { get; set; }
    }
}
