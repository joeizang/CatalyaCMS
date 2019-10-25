public class School : BaseEntity
    {

        private SchoolCreateModel CreateStateTracker { get; set; }

        public School(SchoolCreateModel model)
        {
            Pictures = new List<Picture>();
            Articles = new List<Article>();
            Opinions = new List<Opinion>();

            CreateStateTracker = model;

            Title = CreateStateTracker.SchoolTitle;
            Motto = CreateStateTracker.SchoolMotto;
            CreatedDate = DateTimeOffset.UtcNow;
        }

        public School()
        {
            Article = new List<Article>();
            Pictures = new List<Picture>();
            Opinions = new List<Opinion>();
        }


        private void ActivateSchoolAtCreation()
        {
            if (CreateStateTracker.Activation)
            {
                ActivationDate = DateTimeOffset.UtcNow;
            }
        }


        public string Title { get; set; }

        public string motto { get; set; }

        public DateTimeOffset DateEstablished { get; set; }

        public ICollection<Article> Articles { get; set; }

        public ICollection<Picture> Pictures { get; set; }
        
        public SiteUser SiteUser { get; set; } //Authors
        
        public string SiteUserId { get; set; }

        public ICollection<ArticleTags> ArticleTags { get; set; }

        public ICollection<Opinion> Opinions { get; set; }
    }
