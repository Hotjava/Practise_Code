using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPPatterns.Chap4.ActiveReport.Model;

namespace ASPPatterns.Chap4.ActiveReport.UI.Controllers
{
    public class BlogController : Controller
    {
        //
        // GET: /Blog/

        public ActionResult Index()
        {
            Post[] posts = Post.FindAll();

            if (posts.Count() > 0)
            {
                ViewData["AllPosts"] = posts;
                ViewData["LatestPost"] = Post.FindLatestPost();
                return View();
            }
            else
            {
                return Create();
            }
        }

        public ActionResult CreateComment(string id, FormCollection collection)
        {
            int postId = 0;
            int.TryParse(id, out postId);
            Post post = Post.Find(postId); 

            Comment comment = new Comment();
            comment.Post = post;
            comment.Auther = Request.Form["Author"];
            comment.DateAdded = DateTime.Now;
            comment.Text = Request.Form["Comment"]; 
            comment.Save();

            return Detail(post.Id.ToString());

        }


        public ActionResult Details(string id)
        {
            ViewData["AllPosts"] = Post.FindAll();
            int postId = 0;
            int.TryParse(id, out postId);
            ViewData["LastestPost"] = Post.Find(postId);

            return View("Index");
        }
       
        public ActionResult Create()
        {
            return View("AddPost");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            Post  post = new Post();
            post.DataAdded = DateTime.Now;
            post.Subject = Request.Form["Subject"];
            post.Text = Request.Form["Content"]; 
            post.Save();

            return Details(post.Id.ToString());
        }


    }
}
