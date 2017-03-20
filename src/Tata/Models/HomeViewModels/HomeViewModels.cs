using System.Collections.Generic;
using Tata.Entities;

namespace Tata.Models
{
    public class HomeViewModels
    {
        public List<Product> HomeProductFeature { get; set; }
        public List<Article> HomeServiceArticle { get; set; }
        public List<Article> HomeNewsArticle { get; set; }
        public List<Setting> HomeSliderBox { get; set; }
        public List<Setting> HomeSliderBanner { get; set; }
        public List<Setting> HomeSliderLink { get; set; }
        public List<Setting> HomeServiceFeature { get; set; }
        public List<Setting> HomeServiceIntro { get; set; }
        public List<Setting> HomeBanner { get; set; }
        public string HomeServiceTitle { get; set; }
        public string HomeServiceProperties { get; set; }
        public string HomePartnerIntro { get; set; }
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

    public class PartnerViewModel
    {
        public string PartnerExcert { get; set; }
        public List<Setting> Partners { get; set; }
    }

    public class ContactViewModel
    {
        public string ContactSalesTel { get; set; }
        public string ContactSupportTel { get; set; }
        public string ContactDirectorTel { get; set; }
        public string ContactAddress { get; set; }
        public string ContactSalesEmail { get; set; }
        public string ContactSupportEmail { get; set; }
        public string ContactDirectorEmail { get; set; }
        public string ContactLongitude { get; set; }
        public string ContactLatitude { get; set; }
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
