using System;
using System.Collections.Generic;
using System.Text;
using CatalyaCMS.Domain.DomainModels;

namespace CatalyaCMS.Domain.ApiModels.Opinion
{
    public class CreateOpinionModel
    {
        public string UserId { get; set; }

        public OpinionType Opinion { get; set; }

    }
}
