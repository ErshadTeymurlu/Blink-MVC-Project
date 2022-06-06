using Blink.DAL;
using Blink.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blink.Controllers
{
    public class PostsController : Controller
    {
        private AppDbContext _db { get; }
        public PostsController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> BlogGrid()
        {
            PostViewModel pvm = new PostViewModel()
            {
                Posts = await _db.BlogPosts.Include(element => element.Category).ToListAsync(),
                Categories = await _db.Categories.ToListAsync()
            };

            return View(pvm);
        }

        public IActionResult BlogSingle(int? id)
        {
            if (id != null)
            {
                PostViewModel pvm = new PostViewModel();
                pvm.Posts = new List<BlogPost>();
                pvm.Posts.Add(_db.BlogPosts.Where(element => element.Id == id).Include(el=>el.Category).Include(el => el.Comments).FirstOrDefault());
                return View(pvm);
            }
            else return NotFound();
        }
        public async Task<IActionResult> AddComment(Comment comment)
        {
            await _db.Comments.AddAsync(comment);
            _db.SaveChanges();
            return RedirectToAction("bloggrid");
        }

       
    }
}
