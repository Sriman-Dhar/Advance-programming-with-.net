using IntroAPI.EF;
using IntroAPI.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroAPI.Controllers
{
    public class IntroAPIController : ApiController
    {
        private readonly NewsContext _context = new NewsContext();


        [HttpGet]
        [Route("api/category/all")]
        public HttpResponseMessage GetAllCategories()
        {
            try
            {
                var categories = _context.Categories.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, categories);
            }catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpGet]
        [Route("api/category/{id}")]
        public HttpResponseMessage GetCategoryById(int id)
        {
            var category = _context.Categories.Find(id);
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, category);
            }catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/category/create")]
        public HttpResponseMessage CreateCategory(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Category Created!!" });
            }catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/category/edit")]
        public HttpResponseMessage UpdateCategory(Category upcategory)
        {
            try
            {
                var category = _context.Categories.Find(upcategory.Id);
                _context.Entry(category).CurrentValues.SetValues(upcategory);
                _context.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Category Updated!!" });
            
            }catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/category/delete/{id}")]
        public HttpResponseMessage DeleteCategoryById(int id)
        {
            try
            {
                var category = _context.Categories.Find(id);
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Category is Deleted!!" });
            
            }catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpGet]
        [Route("api/news/all")]
        public HttpResponseMessage GetAllNews()
        {
            try
            {
                var news = _context.News.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, news);
            }catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/news/{id}")]
        public HttpResponseMessage GetNewsById(int id)
        {
            try
            {
                var news = _context.News.Find(id);
                return Request.CreateResponse(HttpStatusCode.OK, news);
            }catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/news/{date}")]
        public HttpResponseMessage GetNewsByDate(DateTime date)
        {
            try
            {
                var news = _context.News.Find(date);
                return Request.CreateResponse(HttpStatusCode.OK, news);
            }catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/news/category/{category_name}")]
        public HttpResponseMessage GetNewsByCategoryName(string category_name)
        {
            try
            {
                var news = (from n in _context.News
                            where n.Category.Name == category_name
                            select n).ToList();

                return Request.CreateResponse(HttpStatusCode.OK, news);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/news/{date}/{category_name})")]
        public HttpResponseMessage GetNewsByDandCname(DateTime date, string category_name )
        {
            try
            {
                var news = (from n in _context.News
                            where n.Date.Date == date.Date && n.Category.Name == category_name
                            select n).ToList();

                return Request.CreateResponse(HttpStatusCode.OK, news);
            }catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/news/create")]

        public HttpResponseMessage CreateNews(News news)
        {
            try
            {
                _context.News.Add(news);
                _context.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "News Created!!" });
            }catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/news/edit")]
        public HttpResponseMessage UpdateNews(News Updatenews)
        {
            try
            {
                var news = _context.News.Find(Updatenews.Id);
                _context.Entry(news).CurrentValues.SetValues(Updatenews);
                _context.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "News Updated!!" });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/news/delete/{id}")]
        public HttpResponseMessage DeleteNewsbyId (int id)
        {
            try
            {
                var news = _context.News.Find(id);
                _context.News.Remove(news);
                _context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "News Deleted!!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

    }
}
