
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CatalyaCMS.Domain.ApiModels.Opinion;
using CatalyaCMS.Domain.DomainModels;
using CatalyaCMS.Infrastructure.Abstractions;
using CatalyaCMS.Infrastructure.Queries.Opinions;

namespace CatalyaCMS.Infrastructure.Services
{
    public class OpinionDataService
    {
        private readonly IRepository<Opinion> _repo;
        private readonly IRepository<Article> _aRepo;

        private IncludeParams<Article> Params =>
            new IncludeParams<Article>
            {
                Includes = new List<Expression<Func<Article, object>>>
                {
                    a => a.Opinions,
                    a => a.SiteUser
                }
            };

        private IncludeParams<Opinion> OpinionIncludes =>
            new IncludeParams<Opinion>
            {
                Includes = new List<Expression<Func<Opinion, object>>>
                {
                    o => o.Article,
                    o => o.SiteUser
                }
            };
        
        public OpinionDataService(IRepository<Opinion> repo, IRepository<Article> repo1)
        {
            _repo = repo;
            _aRepo = repo1;
        }

        /// <summary>
        /// Get all the opinions that a particular user has given across all articles, comments and similar.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<List<OpinionListModel>> GetAllOpinionsByUser(OpinionListSpecificationQuery query)
        {
            var oquery = _repo.Query(query, null);

            var result = await oquery.Select(o => new OpinionListModel
            {
                MemberId = o.SiteUserId,
                OpinionId = o.Id
            }).ToListAsync();
            
            result.ForEach(o =>
            {
                var aQuery = _aRepo.Query(Params, new ArticleOpinionSpecificationQuery(o.OpinionId, o.MemberId));
                aQuery.ToList().ForEach(a =>
                {
                    if (a.PublishDate != null) o.ArticleDate = a.PublishDate.Value;
                    o.ArticleId = a.Id;
                    o.CommentCount = a.Opinions.Count;
                });
            });
            return result;
        }


        /// <summary>
        /// Get the details of a single opinion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="spec"></param>
        /// <returns>OpinionDetailModel</returns>
        public Task<OpinionDetailModel> GetOpinion(string id, OpinionDetailSpecificationModel spec)
        {
            var opinion = _repo.Query(OpinionIncludes, spec).AsNoTracking().Select(o => new OpinionDetailModel
            {
                ArticleName = o.Article.Title,
                OpinionGivenAt = o.CreatedDate,
                OpinionGivenBy = o.SiteUser.AuthorName, //this should be by readers not authors
                OpinionTypeCount = o.Article.Opinions.Count
            }).SingleOrDefaultAsync();
            return opinion;
        }

        public async Task CreateOpinion(CreateOpinionModel model)
        {
            //find user with Id
            var user = await SiteUser.FindByIdAsync(model.UserId);

            model.UserId = user.Id; //reallocate the id properly

            var opinion = new Opinion(model);

            _repo.Add(opinion);
        }

        public UserManager<SiteUser> SiteUser { get; set; } //this has to be initialized by DI.
    }    
}