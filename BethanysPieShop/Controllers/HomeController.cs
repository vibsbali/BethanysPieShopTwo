using System.Linq;
using BethanysPieShop.DataAccess;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Pie Overview";

            var pies = _pieRepository.GetAllPies().OrderBy(p => p.Name);

            var vm = new HomeViewModel
            {
                Title = "Welcome to Bethany's Pie Shop",
                Pies = pies.ToList()
            };

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();

            return View(pie);
        }
    }
}
