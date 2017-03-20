using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Entities;
using Tata.Entities.Enums;
using Tata.Models;
using TaTa.DataAccess;
using TaTa.DataAccess.Repositories;

namespace Tata.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUowProvider _uowProvider;

        public HomeController(IUowProvider uowProvider)
        {
            _uowProvider = uowProvider;
        }

        public async Task<IActionResult> Index()
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                IRepository<Setting> settingRepo = uow.GetRepository<Setting>();
                IRepository<Product> productRepo = uow.GetRepository<Product>();
                IRepository<Article> articleRepo = uow.GetRepository<Article>();
                HomeViewModels model = new HomeViewModels();
                IEnumerable<Setting> homeSettings = await settingRepo.QueryAsync(s => s.Section == "Home");
                string[] productFeatureIds;
                string[] serviceArticleIds;

                if (homeSettings.Any())
                {
                    model.HomeSliderBox = homeSettings.Where(s => s.Name == "HomeSliderBox")
                        .OrderBy(s => s.Priority)
                        .ToList();

                    model.HomeSliderLink = homeSettings.Where(s => s.Name == "HomeSliderLink")
                        .OrderBy(s => s.Priority)
                        .ToList();

                    model.HomeSliderBanner = homeSettings.Where(s => s.Name == "HomeSliderBanner")
                        .OrderBy(s => s.Priority)
                        .ToList();

                    model.HomeServiceFeature = homeSettings.Where(s => s.Name == "HomeServiceFeature")
                        .OrderBy(s => s.Priority)
                        .ToList();

                    model.HomeServiceIntro = homeSettings.Where(s => s.Name == "HomeServiceIntro")
                        .OrderBy(s => s.Priority)
                        .ToList();

                    model.HomeBanner = homeSettings.Where(s => s.Name == "HomeBanner")
                        .OrderBy(s => s.Priority)
                        .ToList();

                    model.HomeServiceTitle = homeSettings.SingleOrDefault(s => s.Name == "HomeServiceTitle").Value;
                    model.HomePartnerIntro = homeSettings.SingleOrDefault(s => s.Name == "HomePartnerIntro").Value;
                    model.HomeServiceProperties = homeSettings.SingleOrDefault(s => s.Name == "HomeServiceProperties").Value;

                    serviceArticleIds = homeSettings.SingleOrDefault(s => s.Name == "HomeServiceArticles").Value.Split(',');
                    productFeatureIds = homeSettings.SingleOrDefault(s => s.Name == "HomeProductFeature").Value.Split(',');

                    model.HomeServiceArticle = (await articleRepo.QueryAsync(a => serviceArticleIds.Any(s => s.Equals(a.Id.ToString())),
                                                                            null,
                                                                            a => a.Include(ar => ar.CreatedUser))).ToList();

                    model.HomeNewsArticle = (await articleRepo.QueryAsync(a => a.ArtType == ArticleType.News,
                                                        a => a.OrderBy(ar => ar.Priority),
                                                        a => a.Include(ar => ar.CreatedUser)))
                                                        .Skip(0).Take(3).ToList();

                    model.HomeProductFeature = (await productRepo.QueryAsync(p => productFeatureIds.Any(s => s.Equals(p.Id.ToString())),
                                                                            null,
                                                                            p => p.Include(pr => pr.Properties)
                                                                                  .Include(pr => pr.Prices))).ToList();
                }

                return View(model);
            }
        }

        public async Task<IActionResult> About()
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                IRepository<Setting> repo = uow.GetRepository<Setting>();
                AboutViewModel model = new AboutViewModel();
                IEnumerable<Setting> aboutSettings = await repo.QueryAsync(s => s.Section == "About");

                if (aboutSettings.Any())
                {
                    model.AboutExcert = aboutSettings.SingleOrDefault(s => s.Name == "AboutExcert").Value;
                    model.AboutServices = aboutSettings.Where(s => s.Name == "AboutService")
                        .OrderBy(s => s.Priority)
                        .ToList();
                    model.AboutPartners = aboutSettings.Where(s => s.Name == "AboutPartner")
                        .OrderBy(s => s.Priority)
                        .ToList();
                }

                return View(model);
            }
        }

        public async Task<IActionResult> Article(int id)
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                var articleRepo = uow.GetRepository<Article>();
                ArticleViewModel models = new ArticleViewModel();

                models.CurrentArticle = await articleRepo.GetAsync(id);
                models.RelatedArticles = (await articleRepo.QueryAsync(a => a.ArtType == models.CurrentArticle.ArtType,
                                                                        null,
                                                                        a => a.Include(ar => ar.CreatedUser))).ToList();

                return View(models);
            }
        }

        public async Task<IActionResult> Contact()
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                IRepository<Setting> repo = uow.GetRepository<Setting>();
                ContactViewModel model = new ContactViewModel();
                IEnumerable<Setting> aboutSettings = await repo.QueryAsync(s => s.Section == "Contact");

                if (aboutSettings.Any())
                {
                    model.ContactSalesTel = aboutSettings.SingleOrDefault(s => s.Name == "ContactSalesTel").Value;
                    model.ContactSupportTel = aboutSettings.SingleOrDefault(s => s.Name == "ContactSupportTel").Value;
                    model.ContactDirectorTel = aboutSettings.SingleOrDefault(s => s.Name == "ContactDirectorTel").Value;
                    model.ContactAddress = aboutSettings.SingleOrDefault(s => s.Name == "ContactAddress").Value;
                    model.ContactSalesEmail = aboutSettings.SingleOrDefault(s => s.Name == "ContactSalesEmail").Value;
                    model.ContactSupportEmail = aboutSettings.SingleOrDefault(s => s.Name == "ContactSupportEmail").Value;
                    model.ContactDirectorEmail = aboutSettings.SingleOrDefault(s => s.Name == "ContactDirectorEmail").Value;
                    model.ContactLongitude = aboutSettings.SingleOrDefault(s => s.Name == "ContactLongitude").Value;
                    model.ContactLatitude = aboutSettings.SingleOrDefault(s => s.Name == "ContactLatitude").Value;
                }

                return View(model);
            }
        }

        public IActionResult Domain()
        {
            return View();
        }

        public IActionResult DomainPriceList()
        {
            return View();
        }

        public async Task<IActionResult> Partner()
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                IRepository<Setting> repo = uow.GetRepository<Setting>();
                PartnerViewModel model = new PartnerViewModel();
                IEnumerable<Setting> aboutSettings = await repo.QueryAsync(s => s.Section == "Partner");

                if (aboutSettings.Any())
                {
                    model.PartnerExcert = aboutSettings.SingleOrDefault(s => s.Name == "PartnerExcert").Value;
                    model.Partners = aboutSettings.Where(s => s.Name == "PartnerInfo")
                        .OrderBy(s => s.Priority)
                        .ToList();
                }

                return View(model);
            }
        }

        public async Task<IActionResult> Promotion()
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                var articleRepo = uow.GetRepository<Article>();
                IEnumerable<Article> models = await articleRepo.QueryAsync(a => a.ArtType == ArticleType.PromotionContent, 
                                                                           a => a.OrderBy(ar => ar.Priority));

                return View(models.Skip(0).Take(8).ToList());
            }
        }

        public async Task<IActionResult> Support()
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                IRepository<Setting> repo = uow.GetRepository<Setting>();
                IEnumerable<Setting> supportQuestions = await repo.QueryAsync(s => s.Section == "SupportQuestion");

                return View(supportQuestions.ToList());
            }
        }

        public async Task<IActionResult> VpsPage()
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                IRepository<Product> productRepo = uow.GetRepository<Product>();
                IEnumerable<Product> allProducts = await productRepo.GetAllAsync(p => p.OrderBy(pr => pr.Priority), 
                                                                                 p => p.Include(pr => pr.Properties)
                                                                                       .Include(pr => pr.Prices));

                return View(allProducts.Skip(0).Take(8).ToList());
            }
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
