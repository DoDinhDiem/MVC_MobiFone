using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobifone_DATN.Models;

namespace Mobifone_DATN.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("Admin")]
    [Route("Admin/GioiThieu")]
    public class GioiThieuController : Controller
    {
        private readonly DATN_MobifoneContext _context;
    
        public GioiThieuController(DATN_MobifoneContext context)
        {
            _context = context;
        }
        [Route("")]
        [HttpGet]
        public IActionResult GioiThieu()
        {
            return View();
        }

        [Authorize(Roles = "Role_Admin")]
        [Route("Search_GioiThieu")]
        [HttpGet]
        public IActionResult Search([FromQuery] string? title, int page = 1, int pageSize = 10)
        {
            try
            {
                var query = _context.GioiThieus.AsQueryable();

                if (!string.IsNullOrEmpty(title))
                {
                    query = query.Where(l => l.Title.Contains(title));
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
      
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Role_Admin")]
        [Route("Creat_GioiThieu")]
        [HttpPost]
        public JsonResult create([FromBody] GioiThieu model)
        {
            try
            {
                _context.GioiThieus.Add(model);
                _context.SaveChanges();
                return Json(new {message = "Thêm giới thiệu thành công"});
            }catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = "Role_Admin")]
        [Route("Update_GioiThieu")]
        [HttpPut]
        public JsonResult update([FromBody] GioiThieu model)
        {
            try
            {
                var query = _context.GioiThieus.Find(model.Id);
                if(query == null)
                {
                    return Json(new { message = "Không tìm thấy dữ liệu" });
                }
                query.Title = model.Title;
                query.NoiDung = model.NoiDung;
                _context.SaveChanges();
                return Json(new {message = "Cập nhập giới thiệu thành công"});
            }catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = "Role_Admin")]
        [Route("GetById_GioiThieu")]
        [HttpGet]
        public IActionResult getById(int id)
        {
            try
            {
                var query = _context.GioiThieus.Find(id);
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

        [Authorize(Roles = "Role_Admin")]
        [Route("Delete_GioiThieu")]
        [HttpDelete]
        public JsonResult deleteById(int id)
        {
            try
            {
                var query = _context.GioiThieus.Find(id);
                if (query == null)
                {
                    return Json(new { message = "Không tìm thấy dữ liệu" });
                }
                _context.GioiThieus.Remove(query);
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
