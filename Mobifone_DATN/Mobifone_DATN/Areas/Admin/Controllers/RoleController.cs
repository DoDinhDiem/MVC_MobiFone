using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobifone_DATN.Models;

namespace Mobifone_DATN.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("Admin")]
    [Route("Admin/Role")]
    public class RoleController : Controller
    {
        private readonly DATN_MobifoneContext _context;

        public RoleController(DATN_MobifoneContext context)
        {
            _context = context;
        }
        [Route("")]
        [HttpGet]
        public IActionResult Role()
        {
            return View();
        }

        [Authorize(Roles = "Role_Admin")]
        [Route("Search_Role")]
        [HttpGet]
        public IActionResult Search([FromQuery] string? title, int page = 1, int pageSize = 10)
        {
            try
            {
                var query = _context.Roles.AsQueryable();

                if (!string.IsNullOrEmpty(title))
                {
                    query = query.Where(l => l.TenRole.Contains(title));
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

        [Authorize(Roles = "Role_Admin")]
        [Route("Creat_Role")]
        [HttpPost]
        public JsonResult create([FromBody] Role model)
        {
            try
            {
                _context.Roles.Add(model);
                _context.SaveChanges();
                return Json(new { message = "Thêm quyền thành công" });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = "Role_Admin")]
        [Route("Update_Role")]
        [HttpPut]
        public JsonResult update([FromBody] Role model)
        {
            try
            {
                var query = _context.Roles.Find(model.Id);
                if (query == null)
                {
                    return Json(new { message = "Không tìm thấy dữ liệu" });
                }
                query.TenRole = model.TenRole;
                _context.SaveChanges();
                return Json(new { message = "Cập nhập quyền thành công" });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = "Role_Admin")]
        [Route("GetById_Role")]
        [HttpGet]
        public IActionResult getById(int id)
        {
            try
            {
                var query = _context.Roles.Find(id);
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
        [Route("Delete_Role")]
        [HttpDelete]
        public JsonResult deleteById(int id)
        {
            try
            {
                var query = _context.Roles.Find(id);
                if (query == null)
                {
                    return Json(new { message = "Không tìm thấy dữ liệu" });
                }
                _context.Roles.Remove(query);
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
