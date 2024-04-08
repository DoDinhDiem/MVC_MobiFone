using Microsoft.AspNetCore.Mvc;
using Mobifone_DATN.Models;
using System.Diagnostics;

namespace Mobifone_DATN.Controllers
{
    public class HomeController : Controller
    {
        private readonly DATN_MobifoneContext _context;
        public HomeController(DATN_MobifoneContext context)
        {
            _context = context;
        }
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("GetTinTuc")]
        [HttpGet]
        public IActionResult GetTinTuc()
        {
            try
            {
                var query = _context.TinTucs.OrderByDescending(x => x.CreatedAt).Take(6).ToList();
                return Json(query);
            }catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [Route("GetSlide")]
        [HttpGet]
        public IActionResult GetSlide()
        {
            try
            {
                var query = _context.Slides.ToList();
                return Json(query);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
