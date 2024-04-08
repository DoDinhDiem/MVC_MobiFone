using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobifone_DATN.Models;

namespace Mobifone_DATN.Controllers
{
   
    public class TuyenDungController : Controller
    {
        private readonly DATN_MobifoneContext _context;
        public TuyenDungController(DATN_MobifoneContext context)
        {
            _context = context;
        }

        [Route("TuyenDung")]
        public IActionResult TuyenDung()
        {
            return View();
        }

        [Route("GetTuyenDung")]
        [HttpGet]

        public IActionResult Search([FromQuery] int page = 1, int pageSize = 2)
        {
            try
            {
                var query = _context.TuyenDungs.AsQueryable();

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
