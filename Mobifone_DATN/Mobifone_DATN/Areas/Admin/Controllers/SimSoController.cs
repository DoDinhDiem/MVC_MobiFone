using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobifone_DATN.Models;

namespace Mobifone_DATN.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("Admin")]
    [Route("Admin/SimSo")]
    public class SimSoController : Controller
    {
        private readonly DATN_MobifoneContext _context;

        public SimSoController(DATN_MobifoneContext context)
        {
            _context = context;
        }
        [Route("")]
        [HttpGet]
        public IActionResult SimSo()
        {
            return View();
        }

        [Authorize(Roles = "Role_Admin, Role_User")]
        [Route("Search_SimSo")]
        [HttpGet]
        public IActionResult Search([FromQuery] string? title, int page = 1, int pageSize = 10)
        {
            try
            {
                var query = _context.SimSos.AsQueryable();

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

        [Authorize(Roles = "Role_Admin, Role_User")]
        [Route("Creat_SimSo")]
        [HttpPost]
        public JsonResult create([FromBody] SimSo model)
        {
            try
            {
                _context.SimSos.Add(model);
                _context.SaveChanges();
                return Json(new { message = "Thêm sim số thành công" });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = "Role_Admin, Role_User")]
        [Route("Update_SimSo")]
        [HttpPut]
        public JsonResult update([FromBody] SimSo model)
        {
            try
            {
                var query = _context.SimSos.Find(model.Id);
                if (query == null)
                {
                    return Json(new { message = "Không tìm thấy dữ liệu" });
                }
                query.SoThueBao = model.SoThueBao;
                query.LoaiThueBao = model.LoaiThueBao;
                query.LoaiSo = model.LoaiSo;
                query.GiaBan = model.GiaBan;
                query.TrangThai = model.TrangThai;
                _context.SaveChanges();
                return Json(new { message = "Cập nhập sim số thành công" });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = "Role_Admin, Role_User")]
        [Route("GetById_SimSo")]
        [HttpGet]
        public IActionResult getById(int id)
        {
            try
            {
                var query = _context.SimSos.Find(id);
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
        [Route("Delete_SimSo")]
        [HttpDelete]
        public JsonResult deleteById(int id)
        {
            try
            {
                var query = _context.SimSos.Find(id);
                if (query == null)
                {
                    return Json(new { message = "Không tìm thấy dữ liệu" });
                }
                _context.SimSos.Remove(query);
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
