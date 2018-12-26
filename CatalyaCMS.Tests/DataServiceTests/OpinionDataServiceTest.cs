using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using CatalyaCMS.Domain.ApiModels.Opinion;
using CatalyaCMS.Domain.DomainModels;
using CatalyaCMS.Infrastructure.Abstractions;
using CatalyaCMS.Infrastructure.Queries;
using CatalyaCMS.Infrastructure.Queries.Opinions;
using CatalyaCMS.Infrastructure.Services;
using Xunit;

namespace CatalyaCMS.Tests.DataServiceTests
{
    public class OpinionDataServiceTest
    {


        [Fact]
        public async Task GetAllOpinionsByUser_ReturnsListOfOpinionListModel()
        {
            //Arrange
            var specQuery = new Mock<OpinionListSpecificationQuery>().Object;
            var includes = new IncludeParams<Article>
            {
                Includes = new List<Expression<Func<Article, object>>>
                {
                    a => a.Opinions,
                    a => a.SiteUser
                }
            };

            var opinionRepo = new Mock<IRepository<Opinion>>();

            //var opinionList = new Mock<IQueryable<Opinion>>();
            //opinionList.Setup(x => x.GetEnumerator())
            //    .Returns(new TestAsyncEnumerator<Opinion>(GetQueryableOpinions().GetEnumerator()));

            opinionRepo.Setup(r => r.Query(specQuery, null))
                .Returns(GetQueryableOpinions());

            var articlerepo = new Mock<IRepository<Article>>();

            var list = new List<OpinionListModel>
            {
                new OpinionListModel
                {
                    OpinionId = Guid.NewGuid().ToString(),
                    MemberId = Guid.NewGuid().ToString()
                },
                new OpinionListModel
                {
                    OpinionId = Guid.NewGuid().ToString(),
                    MemberId = Guid.NewGuid().ToString()
                }
            };

            list.ForEach((o) =>
            {
                articlerepo.Setup(a => a.Query(includes,
                        new ArticleOpinionSpecificationQuery(o.OpinionId, o.MemberId)))
                    .Returns(new List<Article>().AsQueryable());
            });
            

            var dataService = new OpinionDataService(opinionRepo.Object, articlerepo.Object);

            //Act
            var result = await dataService.GetAllOpinionsByUser(specQuery);

            //Assert
            Assert.True(result != null);
            Assert.Equal(result.Count, list.Count);
        }


        private IQueryable<Opinion> GetQueryableOpinions()
        {
            var list = new List<Opinion>
            {
                new Opinion(),
                new Opinion()
            };
            return list.AsQueryable();
        }
    }
}