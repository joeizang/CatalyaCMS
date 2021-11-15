using CatalyaCMS.Domain.BaseTypes;
using CatalyaCMS.Domain.DomainModels;
using System;
using System.Collections.Generic;
using CatalyaCMS.Domain.ApiModels.School;

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
        Articles = new List<Article>();
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
    public string Motto { get; private set; }

    public DateTimeOffset DateEstablished { get; set; }

    public ICollection<Article> Articles { get; set; }

    public ICollection<Picture> Pictures { get; set; }

    public SiteUser SiteUser { get; set; } //Authors

    public string SiteUserId { get; set; }

    public ICollection<ArticleTags> ArticleTags { get; set; }

    public ICollection<Opinion> Opinions { get; set; }
    public DateTimeOffset ActivationDate { get; private set; }
}
