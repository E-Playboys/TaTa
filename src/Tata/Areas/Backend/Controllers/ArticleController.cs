using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tata.Areas.Backend.Models.Article;
using Tata.Entities;
using TaTa.DataAccess;

namespace Tata.Areas.Backend.Controllers
{
    [Area("Backend")]
    [Authorize(Roles = "Administrator")]
    public class ArticleController : Controller
    {
        private readonly IUowProvider _uowProvider;

        public ArticleController(IUowProvider uowProvider)
        {
            _uowProvider = uowProvider;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public async Task<IActionResult> List(int skip = 0, int take = 10)
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                var productRepo = uow.GetRepository<Article>();
                IEnumerable<Article> Articles = (await productRepo.GetAllAsync()).OrderBy(s => s.Id);
                IEnumerable<ArticleModel> models = Mapper.Instance.Map<IEnumerable<Article>,IEnumerable<ArticleModel>>(Articles);

                return View(models);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                var productRepo = uow.GetRepository<Article>();
                Article Article = await productRepo.GetAsync(id);
                ArticleModel models = Mapper.Instance.Map<Article, ArticleModel>(Article);

                return View(models);
            }
        }

        [HttpPost]
        public IActionResult Details(ArticleModel model)
        {
            using (IUnitOfWork uow = _uowProvider.CreateUnitOfWork())
            {
                if (ModelState.IsValid)
                {
                    var ArticleRepo = uow.GetRepository<Article>();
                    Article updateArticle = Mapper.Map<ArticleModel, Article>(model);
                    updateArticle = ArticleRepo.Update(updateArticle);
                }

                return RedirectToAction("Details", new { id = model.Id });
            }
        }
    }
}
