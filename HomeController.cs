using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudySmartDbContext _context;
        public HomeController(ILogger<HomeController> logger,StudySmartDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Books(int? id)
        {
            if (id != null)
            {
                var librarybookInDb = _context.About.SingleOrDefault(expense =>
                expense.Id == id);
                return View(librarybookInDb);
            }
            return View();
           
            
        }
        public IActionResult DeleteBooks(int id)
        {
            var booksInDb = _context.About.SingleOrDefault(data => data.Id == id);
            _context.About.Remove(booksInDb);
            _context.SaveChanges();
            return RedirectToAction("About");
        }
        
        public IActionResult About()
        {
            var alldata = _context.About.ToList();
            var totalbooks = alldata.Sum(x => x.Count);
            ViewBag.About = totalbooks;
            return View(alldata);
        }
        public IActionResult BooksForm(Data model)
        {
            if (model.Id == 0)
            {
                _context.About.Add(model);
            }
            else
            {
                _context.About.Update(model);
            }

            _context.SaveChanges();

            return RedirectToAction("About");
        }



        //public IActionResult Privacy()
        //{
            //return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
