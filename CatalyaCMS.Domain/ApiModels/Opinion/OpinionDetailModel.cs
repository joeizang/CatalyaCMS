using System;
using System.Collections.Generic;
using System.Text;

namespace CatalyaCMS.Domain.ApiModels.Opinion
{
    public class OpinionDetailModel
    {
        public string ArticleName { get; set; }

        public int OpinionTypeCount { get; set; }

        public DateTimeOffset OpinionGivenAt { get; set; }

        public string OpinionGivenBy { get; set; }

    }
}
