using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Entities;
using Tata.Models;
using TaTa.DataAccess;
using TaTa.DataAccess.Repositories;

namespace Tata.ViewComponents
{
    public class FooterComponent : ViewComponent
    {
        private readonly IUowProvider _uowProvider;

        public FooterComponent(IUowProvider uowProvider)
        {
            _uowProvider = uowProvider;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                IRepository<Setting> repo = uow.GetRepository<Setting>();
                FooterComponentModel model = new FooterComponentModel();
                IEnumerable<Setting> commonSettings = await repo.QueryAsync(s => s.Section == "Common");

                model.CompanyName = commonSettings.SingleOrDefault(s => s.Name == "CompanyName").Value;
                model.CompanySalesTel = commonSettings.SingleOrDefault(s => s.Name == "CompanySalesTel").Value;
                model.CompanySupportTel = commonSettings.SingleOrDefault(s => s.Name == "CompanySupportTel").Value;
                model.CompanyAddress = commonSettings.SingleOrDefault(s => s.Name == "CompanyAddress").Value;
                model.SiteGoogleAnalytics = commonSettings.SingleOrDefault(s => s.Name == "SiteGoogleAnalytics").Value;
                model.CompanyFb = commonSettings.SingleOrDefault(s => s.Name == "CompanyFb").Value;
                model.CompanyYouTube = commonSettings.SingleOrDefault(s => s.Name == "CompanyYouTube").Value;
                model.CompanyTweet = commonSettings.SingleOrDefault(s => s.Name == "CompanyTweet").Value;
                model.CompanyLinkedin = commonSettings.SingleOrDefault(s => s.Name == "CompanyLinkedin").Value;

                return View(model);
            }
        }
    }
}
