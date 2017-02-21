using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Tata.Entities.Enums;

namespace Tata.Entities
{
    public class Article : Tracking
    {
        public string Title { get; set; }
        public string Excerpt { get; set; }
        public string FeatureImg { get; set; }
        [Column(TypeName = "ntext")]
        public string Content { get; set; }
        public ArticleType ArtType { get; set; }
        public int Priority { get; set; }
    }
}
