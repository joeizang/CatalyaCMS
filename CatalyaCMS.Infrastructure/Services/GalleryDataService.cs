using Microsoft.EntityFrameworkCore;
using CatalyaCMS.Domain.ApiModels.Gallery;
using CatalyaCMS.Domain.DomainModels;
using CatalyaCMS.Infrastructure.Abstractions;
using CatalyaCMS.Infrastructure.Queries.GalleryQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CatalyaCMS.Infrastructure.Services
{
    public class GalleryDataService
    {
        private readonly IRepository<Gallery> _repo;

        public IncludeParams<Gallery> Params => new IncludeParams<Gallery>
        {
            Includes = new List<Expression<Func<Gallery, object>>>
            {
                x => x.Pictures
            }
        };

        public GalleryDataService(IRepository<Gallery> repo)
        {
            _repo = repo;
        }

        public Task<List<GalleryListModel>> GetGalleries(/**[FromServices]**/GalleryListQuerySpecification query)
        {
            var queryable = _repo.Query(Params, query);

            var results = queryable.AsNoTracking().Select(g => new GalleryListModel
            {
                GalleryName = g.GalleryName,
                Creator = g.CreatedBy,
                DateCreated = g.CreatedDate,
                Description = g.Description,
                NumberOfImages = g.Pictures.Count
            }).ToListAsync();
            return results;
        }

        public Task<GalleryDetailModel> GetGallery(string id, GalleryDetailQuerySpecification query = null)
        {
            if (query is null)
            {
                var result = _repo.Query(query, g => g.Pictures).AsNoTracking()
                    .Where(g => g.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase));
                var aresult = result.Select(g => new GalleryDetailModel
                {
                    GalleryName = g.GalleryName,
                    PicturesInGallery = g.Pictures.Count,
                    Description = g.Description,
                    DateCreated = g.CreatedDate
                }).SingleOrDefaultAsync();
                return aresult;
            }
            else
            {
                var result = _repo.Query(query, g => g.Pictures).AsNoTracking();
                if (query.Predicates.Any())
                {
                    query.Predicates.ForEach(x => { result = result.Where(x); });
                }

                result = result.Where(g => g.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase));
                return result.Select(g => new GalleryDetailModel
                {
                    GalleryName = g.GalleryName,
                    PicturesInGallery = g.Pictures.Count,
                    Description = g.Description,
                    DateCreated = g.CreatedDate
                }).SingleOrDefaultAsync();
            }
        }

        public void CreateGallery(GalleryCreateModel model)
        {
            var gallery = new Gallery(model);
            _repo.Add(gallery);
        }

        public async Task UpdateGallery(GalleryEditModel model)
        {
            if (!(model is null))
            {
                var gallery = await _repo.FindOne(new CancellationToken(), g => g.Id.Equals(model.Id,
                        StringComparison.InvariantCultureIgnoreCase)).ConfigureAwait(false);
                if (!string.IsNullOrEmpty(model.GalleryName) && !string.IsNullOrEmpty(model.CreatedBy))
                {
                    GetType().GetProperty(nameof(gallery.GalleryName))
                        .SetValue(gallery.GalleryName, model.GalleryName);
                    GetType().GetProperty(nameof(gallery.CreatedBy))
                        .SetValue(gallery.CreatedBy, model.CreatedBy);
                    //Todo: look at situation where change of author is staged to be reviewed later
                    GetType().GetProperty(nameof(gallery.Description))
                        .SetValue(gallery.Description, model.Description);
                    GetType().GetProperty(nameof(gallery.UpdatedDate))
                        .SetValue(gallery.UpdatedDate, DateTimeOffset.UtcNow);
                }
            }

            //TODO: SEND TO NICE ERROR PAGE SAYING THE UPDATE WON'T WORK WITH NULLS.
        }

        public async Task DeleteGallery(string id)
        {
            var gallery = await _repo.FindBy(id);
            _repo.Remove(gallery);
        }

        public void SaveGallery()
        {
            _repo.Commit();
        }
    }
}
