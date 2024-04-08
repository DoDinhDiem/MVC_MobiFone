using Microsoft.AspNetCore.Mvc;
using Mobifone_DATN.Models;

namespace Mobifone_DATN.Controllers
{
    public class LienHeController : Controller
    {
        private readonly DATN_MobifoneContext _context;
        public LienHeController(DATN_MobifoneContext context)
        {
            _context = context;
        }

        [Route("LienHe")]
        public IActionResult LienHe ()
        {
            return View();
        }

        [Route("GetLienHe")]
        [HttpGet]
        public IActionResult GetLienHe()
        {
            try
            {
                var query = _context.LienHes.FirstOrDefault();

                return Json(query);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
