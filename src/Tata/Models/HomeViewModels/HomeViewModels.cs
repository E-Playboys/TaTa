using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tata.Entities;

namespace Tata.Models
{
    public class HomeViewModels
    {
        public IEnumerable<Setting> CommonSettings { get; set; }
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
    }
}
