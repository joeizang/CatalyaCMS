using System.Collections.Generic;
using CatalyaCMS.Domain.ApiModels;
using CatalyaCMS.Domain.ApiModels.Picture;
using CatalyaCMS.Domain.BaseTypes;

namespace CatalyaCMS.Domain.DomainModels
{
    public class Picture : BaseEntity
    {

        private Picture()
        {
            Tags = new List<Tag>();
        }

        public Picture(PictureCreateModel model)
        {
            Create(model);
            Tags = new List<Tag>();
        }

        public Picture(PictureUpdateModel model)
        {
            UpdatePicture(model);
            Tags = new List<Tag>();
        }

        private void UpdatePicture(PictureUpdateModel model)
        {
            if (model is null) return;

            Title = model.PictureTitle;
            Description = model.Description;
            PicturePath = model.PicturePath;
            GalleryId = model.GalleryId;
            Id = model.PictureId;
            //see if the changes to tags can be put in a DomainEvent.
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string PicturePath { get; set; }

        public Gallery Gallery { get; set; }

        public string GalleryId { get; set; }
        
        public ICollection<Tag> Tags { get; set; }

        private void Create(PictureCreateModel model)
        {
            if(model is null) return;

            if (!string.IsNullOrEmpty(model.Title) && !string.IsNullOrEmpty(model.PicturePath))
            {
                Title = model.Title;
                PicturePath = model.PicturePath;
                Description = model.Description;
            }
        }
    }
}