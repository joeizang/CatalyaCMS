using System;
using System.Collections.Generic;
using System.Text;

namespace CatalyaCMS.Domain.ApiModels.Gallery
{
    public class GalleryCreateModel
    {
        public string GalleryName { get; set; }

        public string Description { get; set; }

        public string CreatedBy { get; set; }

        //TODO: ADD PICTURES TO GALLERY AS GALLERY IS BEING CREATED.
    }
}
