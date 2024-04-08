using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobifone_DATN.Models;

namespace Mobifone_DATN.Controllers
{
    public class SimSoController : Controller
    {
        private readonly DATN_MobifoneContext _context;
        public SimSoController(DATN_MobifoneContext context)
        {
            _context = context;
        }

        [Route("SimSo")]
        public IActionResult SimSo()
        {
            return View();
        }

        [Route("Search_SimSo")]
        [HttpGet]
        public IActionResult Search([FromQuery] string? title, int page = 1, int pageSize = 10)
        {
            try
            {
                var query = _context.SimSos.Where(x => x.TrangThai == true).AsQueryable();

                if (!string.IsNullOrEmpty(title))
                {
                    query = query.Where(l => l.SoThueBao.Contains(title));
                }

                var totalItems = query.Count();

                var list = query.Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

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
    }
}
