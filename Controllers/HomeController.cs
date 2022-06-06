using Blink.DAL;
using Blink.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Blink.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _db { get; }
        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _db.BlogPosts.Include(el => el.Category).ToListAsync();
            HomeViewModel hvm = new HomeViewModel()
            {
                BlogPosts = items.TakeLast(3).ToList()
            };
            return View(hvm);
        }
    }
}