using Microsoft.AspNetCore.Mvc;
using Mobifone_DATN.Models;

namespace Mobifone_DATN.Controllers
{
    public class TinTucController : Controller
    {
        private readonly DATN_MobifoneContext _context;
        public TinTucController(DATN_MobifoneContext context)
        {
            _context = context;
        }

        [Route("TinTuc")]
        public IActionResult TinTuc()
        {
            return View();
        }

        [Route("TinTucDetail/{id}")]
        public IActionResult TinTucDetail()
        {
            return View();
        }

        [Route("TinTuc/GetTinTuc")]
        [HttpGet]
        public IActionResult GetGoiCuoc([FromQuery] int page = 1, int pageSize = 10)
        {
            try
            {
                var query = _context.TinTucs.AsQueryable();

                var totalItems = query.Count();

                var list = query.Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

                var response = new
                {
                    TotalItems = totalItems,
                    TotalPages = (int)Math.Ceiling((double)totalItems / pageSize),
                    PageSize = pageSize,
                    PageNumber = page,
                    Items = list
                };

                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("TinTucById/{id}")]
        [HttpGet]
        public IActionResult TinTucById(int id)
        {
            try
            {
                var query = _context.TinTucs.Find(id);
                return Json(query);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
