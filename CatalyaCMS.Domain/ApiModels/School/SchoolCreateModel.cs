using System;
using System.Collections.Generic;
using System.Text;

namespace CatalyaCMS.Domain.ApiModels.School
{
    public class SchoolCreateModel
    {
        public string SchoolTitle { get; internal set; }
        public string SchoolMotto { get; internal set; }
        public bool Activation { get; set; }
    }
}
