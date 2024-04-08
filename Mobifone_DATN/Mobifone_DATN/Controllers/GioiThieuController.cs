using Microsoft.AspNetCore.Mvc;
using Mobifone_DATN.Models;

namespace Mobifone_DATN.Controllers
{
    public class GioiThieuController : Controller
    {
        private readonly DATN_MobifoneContext _context;
        public GioiThieuController(DATN_MobifoneContext context)
        {
            _context = context;
        }

        [Route("GioiThieu")]
        public IActionResult GioiThieu()
        {
            return View();
        }

        [Route("GetGioiThieu")]
        [HttpGet]
        public IActionResult GetGioiThieu()
        {
            try
            {
                var query = _context.GioiThieus.ToList();
                return Json(query);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
