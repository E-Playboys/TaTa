using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Entities;
using Tata.Entities.Enums;
using Tata.Models;
using TaTa.DataAccess;
using TaTa.DataAccess.Query;
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
                HomeViewModels model = new HomeViewModels();
                IEnumerable<Setting> homeSettings = await settingRepo.QueryAsync(s => s.Section == "Home");
                string productFeatureIds;

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

                    productFeatureIds = homeSettings.SingleOrDefault(s => s.Name == "HomeProductFeature").Value;
                    Includes<Product> productInclude = new Includes<Product>(query =>
                    {
                        return query.Include(p => p.Properties)
                                    .Include(p => p.Prices);
                    });

                    model.HomeProductFeature = (await productRepo.QueryAsync(p => productFeatureIds.Contains(p.Id.ToString()),
                                                                            null,
                                                                            productInclude.Expression)).ToList();
                }

                return View(model);
            }
        }

        public IActionResult DomainPriceList()
        {
            return View();
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
                models.RelatedArticles = (await articleRepo.QueryAsync(a => a.ArtType == models.CurrentArticle.ArtType)).ToList();

                return View(models);
            }
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Domain()
        {
            return View();
        }

        public IActionResult Partner()
        {
            return View();
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

        public IActionResult Support()
        {
            return View();
        }

        public async Task<IActionResult> VpsPage()
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                IRepository<Product> productRepo = uow.GetRepository<Product>();
                Includes<Product> productInclude = new Includes<Product>(query =>
                {
                    return query.Include(p => p.Properties)
                                .Include(p => p.Prices);
                });
                IEnumerable<Product> allProducts = await productRepo.GetAllAsync(p => p.OrderBy(pr => pr.Priority), productInclude.Expression);

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
