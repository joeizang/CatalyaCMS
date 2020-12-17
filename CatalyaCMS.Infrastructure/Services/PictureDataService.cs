using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CatalyaCMS.Domain.ApiModels;
using CatalyaCMS.Domain.ApiModels.Picture;
using CatalyaCMS.Domain.DomainModels;
using CatalyaCMS.Infrastructure.Abstractions;
using CatalyaCMS.Infrastructure.Context;
using CatalyaCMS.Infrastructure.Queries.PictureQueries;

namespace CatalyaCMS.Infrastructure.Services
{
    public class PictureDataService
    {
        //TODO: Implement DomainEvent for Logging every action in application.
        private readonly IRepository<Picture> _repo;
        private IRepository<Gallery> _grepo;


        public PictureDataService(IRepository<Picture> repo, IRepository<Gallery> repo1)
        {
            _repo = repo;
            _grepo = repo1;
        }


        public Task<List<PictureListModel>> GetPictures(PictureListQuerySpecification query)
        {
            var pquery = _repo.Query(query, p => p.Gallery);

            var pics = pquery.Select(p => new PictureListModel
            {
                Description = p.Description,
                CreatedDate = p.CreatedDate,
                Id = p.Id,
                PictureTitle = p.Title
            }).ToListAsync();

            return pics;
        }

        public Task<PictureDetailModel> GetPicture(PictureDetailQuerySpecification query)
        {
            var pquery = _repo.Query(query, p => p.Gallery);

            var result = pquery.Select(p => new PictureDetailModel
            {
                Description = p.Description,
                Title = p.Title,
                PicturePath = p.PicturePath,
                Tags = p.Tags.Select(x => x.Name).ToList(),
                GalleryId = p.Gallery.GalleryName
            }).SingleOrDefaultAsync();
            return result;
        }

        public async Task CreatePicture(PictureCreateModel model)
        {
            if (model is null) return;
            var picture = new Picture(model);
            var gallery = await _grepo.FindOne(default,
                g => g.GalleryName.Equals(model.GalleryName, StringComparison.InvariantCultureIgnoreCase));
            picture.Gallery = gallery; //TODO: look into this implementation some more. Can be optimized some more
            _repo.Add(picture);
        }

        public void UpdatePicture(PictureUpdateModel model)
        {
            /**
             * TODO: Make sure that all changes can be done by users that have the right permissions
             * TODO: and these changes should be in the controller not down here in DataAccess.
             */
            if (model is null) return;
            
            var picture = new Picture(model);

            _repo.Update(picture);

        }

        public async Task DeletePicture(PictureDeleteModel model)
        {
            var picture = await _repo.FindOne(default,
                p => p.Id.Equals(model.PictureId, StringComparison.InvariantCultureIgnoreCase));

            _repo.Remove(picture);
        }

        public async Task SavePicture(CancellationToken token)
        {
            await _repo.Commit(token).ConfigureAwait(false);
        }
    }
}
