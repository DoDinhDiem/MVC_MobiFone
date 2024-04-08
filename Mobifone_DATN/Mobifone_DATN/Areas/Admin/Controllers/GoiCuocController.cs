using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobifone_DATN.Models;

namespace Mobifone_DATN.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("Admin")]
    [Route("Admin/GoiCuoc")]
    public class GoiCuocController : Controller
    {
        private readonly DATN_MobifoneContext _context;

        public GoiCuocController(DATN_MobifoneContext context)
        {
            _context = context;
        }
        [Route("")]
        [HttpGet]
        public IActionResult GoiCuoc()
        {
            return View();
        }

        [Authorize(Roles = "Role_Admin, Role_User")]
        [Route("Search_GoiCuoc")]
        [HttpGet]
        public IActionResult Search([FromQuery] string? title, int page = 1, int pageSize = 10)
        {
            try
            {
                var query = _context.GoiCuocs.AsQueryable();

                if (!string.IsNullOrEmpty(title))
                {
                    query = query.Where(l => l.MaGoi.Contains(title));
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

        [Authorize(Roles = "Role_Admin, Role_User")]
        [Route("Creat_GoiCuoc")]
        [HttpPost]
        public JsonResult create([FromBody] GoiCuoc model)
        {
            try
            {
                _context.GoiCuocs.Add(model);

                var newThongTin = new List<ThongTinGoiCuoc>();
                foreach (var thongTin in model.ThongTinGoiCuocs)
                {
                    var infor = new ThongTinGoiCuoc()
                    {
                        GoiCuocId = model.Id,
                        MoTa = thongTin.MoTa
                    };
                    newThongTin.Add(infor);
                }
                _context.SaveChanges();
                return Json(new { message = "Thêm gói cước thành công" });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = "Role_Admin, Role_User")]
        [Route("Update_GoiCuoc")]
        [HttpPut]
        public JsonResult update([FromBody] GoiCuoc model)
        {
            try
            {
                var query = _context.GoiCuocs.Find(model.Id);
                if (query == null)
                {
                    return Json(new { message = "Không tìm thấy dữ liệu" });
                }
                query.MaGoi = model.MaGoi;
                query.Data = model.ThongTinChinh;
                query.GiaGoiCuoc = model.GiaGoiCuoc;

                _context.ThongTinGoiCuocs.RemoveRange(_context.ThongTinGoiCuocs.Where(x => x.GoiCuocId == model.Id));
                foreach (var thongTin in model.ThongTinGoiCuocs)
                {
                    var infor = new ThongTinGoiCuoc()
                    {
                        GoiCuocId = model.Id,
                        MoTa = thongTin.MoTa
                    };
                    query.ThongTinGoiCuocs.Add(infor);
                }

                _context.SaveChanges();
                return Json(new { message = "Cập nhập gói cước thành công" });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = "Role_Admin, Role_User")]
        [Route("GetById_GoiCuoc")]
        [HttpGet]
        public IActionResult getById(int id)
        {
            try
            {
                var query = _context.GoiCuocs.Where(x => x.Id == id)
                                             .Select(x => new
                                             {
                                                 id = x.Id,
                                                 maGoi =  x.MaGoi,
                                                 thongTinChinh = x.ThongTinChinh,
                                                 data = x.Data,
                                                 giaGoiCuoc = x.GiaGoiCuoc,
                                                 listThongTin = _context.ThongTinGoiCuocs.Where(t => t.GoiCuocId == id).ToList()
                                             }).FirstOrDefault();
                if (query == null)
                {
                    return NotFound(new { message = "Không tìm thấy dữ liệu" });
                }
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Role_Admin, Role_User")]
        [Route("Delete_GoiCuoc")]
        [HttpDelete]
        public JsonResult deleteById(int id)
        {
            try
            {
                var query = _context.GoiCuocs.Find(id);
                if (query == null)
                {
                    return Json(new { message = "Không tìm thấy dữ liệu" });
                }
                _context.GoiCuocs.Remove(query);
                _context.SaveChanges();
                return Json(new { message = "Xóa thành công" });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
