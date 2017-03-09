using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Entities.Enums;

namespace Tata.Areas.Backend.Models.Article
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Excert { get; set; }
        public string FeatureImg { get; set; }
        public string Content { get; set; }
        public ArticleType ArtType { get; set; }
        public int Priority { get; set; }

        public string CreatedUserId { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
