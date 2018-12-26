using System;
using System.Collections.Generic;
using System.Text;
using CatalyaCMS.Domain.ApiModels.Gallery;
using CatalyaCMS.Domain.BaseTypes;

namespace CatalyaCMS.Domain.DomainModels
{
    public class Gallery : BaseEntity
    {
        private Gallery()
        {
            Pictures = new List<Picture>();
        }

        public Gallery(GalleryCreateModel model)
        {
            if (!(model is null))
            {
                if (!string.IsNullOrEmpty(model.GalleryName) && !string.IsNullOrEmpty(model.CreatedBy))
                {
                    GalleryName = model.GalleryName;
                    CreatedBy = model.CreatedBy;
                    Description = model.Description;
                    CreatedDate = DateTimeOffset.UtcNow;
                }
                Pictures = new List<Picture>();
            }
                
        }

        public string GalleryName { get; private set; }

        public string Description { get; private set; }

        public string CreatedBy { get; private set; }

        public ICollection<Picture> Pictures { get; private set; }
    }
}
