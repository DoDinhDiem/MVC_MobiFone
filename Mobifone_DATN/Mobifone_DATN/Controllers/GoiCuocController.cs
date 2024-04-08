using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobifone_DATN.Models;

namespace Mobifone_DATN.Controllers
{
    public class GoiCuocController : Controller
    {
        private readonly DATN_MobifoneContext _context;
        public GoiCuocController(DATN_MobifoneContext context)
        {
            _context = context;
        }

        [Route("GoiCuoc")]
        public IActionResult GoiCuoc()
        {
            return View();
        }

        [Route("GetGoiCuoc")]
        [HttpGet]
        public IActionResult GetGoiCuoc([FromQuery] int page = 1, int pageSize = 6)
        {
            try
            {
                var query = _context.GoiCuocs.AsQueryable();

                var totalItems = query.Count();

                var list = query.Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .Select(x => new
                                {
                                    id = x.Id,
                                    maGoi = x.MaGoi,
                                    thongTinChinh = x.ThongTinChinh,
                                    data = x.Data,
                                    giaGoiCuoc = x.GiaGoiCuoc,
                                    listThongTin = _context.ThongTinGoiCuocs.Where(t => t.GoiCuocId == x.Id)
                                                                            .Select(t => new 
                                                                            {
                                                                                moTa = t.MoTa
                                                                            }).ToList()
                                }).ToList();

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
