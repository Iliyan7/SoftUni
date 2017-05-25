using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        public ActionResult Home()
        {
            using (var db = new BlogDbContext())
            {
                var articles = db.Articles
                    .OrderByDescending(x => x.CreatedDate)
                    .Take(5)
                    .Include(a => a.Author)
                    .ToList();

                return View(articles);
            }
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BlogDbContext())
                {
                    var authorId = db.Users
                        .Where(u => u.UserName == this.User.Identity.Name)
                        .First()
                        .Id;

                    article.AuthorId = authorId;

                    db.Articles.Add(article);
                    db.SaveChanges();

                    return RedirectToAction("Home");
                }
            }

            return View(article);
        }

        [Authorize]
        public ActionResult MyPosts()
        {
            using (var db = new BlogDbContext())
            {
                var articles = db.Articles
                    .Where(u => u.Author.UserName == this.User.Identity.Name)
                    .Include(a => a.Author)
                    .ToList();

                return View(articles);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new BlogDbContext())
            {
                var article = db.Articles
                    .Where(a => a.Id == id)
                    .Include(a => a.Author)
                    .First();

                if (article == null)
                {
                    return HttpNotFound();
                }

                var model = new MergedModels();
                model.Article = article;

                var comments = new List<Comment>();

                if (article.CommentIds != null)
                {
                    var commentIds = article.CommentIds
                        .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();

                    foreach (var commentId in commentIds)
                    {
                        var comment = db.Comments
                        .Where(a => a.Id == commentId)
                        .Include(a => a.Author)
                        .First();

                        comments.Add(comment);
                    }
                }

                model.Comments = comments;

                return View(model);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Details(MergedModels models)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BlogDbContext())
                {
                    // Adding comment to the datebase
                    var comment = models.Comment;

                    comment.AuthorId = db.Users
                        .Where(u => u.UserName == this.User.Identity.Name)
                        .First()
                        .Id;

                    db.Comments.Add(comment);
                    db.SaveChanges();

                    // Adding the comment id to article
                    var article = db.Articles
                    .Where(a => a.Id == models.Article.Id)
                    .Include(a => a.Author)
                    .First();

                    article.CommentIds += string.Format("{0}, ", db.Comments
                        .AsEnumerable()
                        .Last()
                        .Id);

                    db.Entry(article).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Details", new { id = article.Id } );
                }
            }

            return View(models);
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new BlogDbContext())
            {
                var article = db.Articles
                    .Where(a => a.Id == id)
                    .First();

                if (article == null)
                {
                    return HttpNotFound();
                }

                if (!IsUserAuthorizedToEdit(article))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }

                var model = new ArticleViewModel();
                model.Id = article.Id;
                model.Title = article.Title;
                model.Content = article.Content;
                model.Tags = article.Tags;

                return View(model);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(ArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BlogDbContext())
                {
                    var article = db.Articles
                        .FirstOrDefault(a => a.Id == model.Id);

                    article.Title = model.Title;
                    article.Content = model.Content;
                    article.Tags = model.Tags;

                    db.Entry(article).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Details", new { id = model.Id });
                }
            }

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(MergedModels models)
        {
            var id = models.Article.Id;

            using (var db = new BlogDbContext())
            {
                var article = db.Articles
                    .Where(a => a.Id == id)
                    .Include(a => a.Author)
                    .First();

                if (article == null)
                {
                    return HttpNotFound();
                }

                db.Articles.Remove(article);
                db.SaveChanges();

                return RedirectToAction("Home");
            }
        }

        public ActionResult Search(string search)
        {
            using (var db = new BlogDbContext())
            {
                var articles = db.Articles
                    .Where(a => a.Title.ToLower().Contains(search.ToLower()) || a.Tags.ToLower().Contains(search.ToLower()))
                    .Include(a => a.Author)
                    .ToList();

                return View(articles);
            }
        }

        private bool IsUserAuthorizedToEdit(Article article)
        {
            bool isAdmin = this.User.IsInRole("Admin");
            bool isAuthor = article.IsAuthor(this.User.Identity.Name);

            return isAdmin || isAuthor;
        }
    }
}