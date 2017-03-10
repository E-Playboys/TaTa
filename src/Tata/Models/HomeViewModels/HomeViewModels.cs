using System.Collections.Generic;
using Tata.Entities;
using Tata.Entities.Enums;

namespace Tata.Models
{
    public class HomeViewModels
    {
        public List<Product> HomeProductFeature { get; set; }
        public List<Setting> HomeSliderBox { get; set; }
        public List<Setting> HomeSliderBanner { get; set; }
        public List<Setting> HomeSliderLink { get; set; }
    }

    public class AboutViewModel
    {
        public string AboutExcert { get; set; }
        public List<Setting> AboutServices { get; set; }
        public List<Setting> AboutPartners { get; set; }
    }

    public class ArticleViewModel
    {
        public Article CurrentArticle { get; set; }
        public List<Article> RelatedArticles { get; set; }
    }

    public class ArticleExcertModel
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public string Title { get; set; }
        public string Excert { get; set; }
        public string FeatureImg { get; set; }
    }

    public class FooterComponentModel
    {
        public string CompanyName { get; set; }
        public string CompanySalesTel { get; set; }
        public string CompanySupportTel { get; set; }
        public string CompanyAddress { get; set; }
        public string SiteGoogleAnalytics { get; set; }
        public string CompanyFb { get; set; }
        public string CompanyYouTube { get; set; }
        public string CompanyTweet { get; set; }
        public string CompanyLinkedin { get; set; }
        public List<Article> FooterArticles { get; set; }
    }
}
