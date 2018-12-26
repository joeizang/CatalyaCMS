using CatalyaCMS.Domain.ApiModels.Opinion;
using CatalyaCMS.Domain.BaseTypes;

namespace CatalyaCMS.Domain.DomainModels
{
    public class Opinion : BaseEntity
    {

        public Opinion(CreateOpinionModel model)
        {
            if (model is null) return;
            Like = model.Opinion;
            SiteUserId = model.UserId;
        }

        public Opinion()
        {
            
        }

        public OpinionType Like { get; set; }

        public string SiteUserId { get; set; }

        public Article Article { get; set; }

        public string ArticleId { get; set; }
        public SiteUser SiteUser { get; set; }
    }
}