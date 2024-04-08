using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobifone_DATN.Models;

namespace Mobifone_DATN.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("Admin")]
    [Route("Admin/TuyenDung")]
    public class TuyenDungController : Controller
    {
        private readonly DATN_MobifoneContext _context;
        public static IWebHostEnvironment _environment;

        public TuyenDungController(DATN_MobifoneContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        [Route("")]
        [HttpGet]
        public IActionResult TuyenDung()
        {
            return View();
        }

        [Authorize(Roles = "Role_Admin")]
        [Route("Search_TuyenDung")]
        [HttpGet]
        public IActionResult Search([FromQuery] string? title, int page = 1, int pageSize = 10)
        {
            try
            {
                var query = _context.TuyenDungs.AsQueryable();

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

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Creat_TuyenDung")]
        [HttpPost]
        public JsonResult create([FromBody] TuyenDung model)
        {
            try
            {
                _context.TuyenDungs.Add(model);
                _context.SaveChanges();
                return Json(new { message = "Thêm tuyển dụng thành công" });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = "Role_Admin")]
        [Route("Update_TuyenDung")]
        [HttpPut]
        public JsonResult update([FromBody] TuyenDung model)
        {
            try
            {
                var query = _context.TuyenDungs.Find(model.Id);
                if (query == null)
                {
                    return Json(new { message = "Không tìm thấy dữ liệu" });
                }
                query.Title = model.Title;
                query.NoiDung = model.NoiDung;
                query.LinkGoogleForm = model.LinkGoogleForm;
                query.Image = model.Image;
                _context.SaveChanges();
                return Json(new { message = "Cập nhập tuyển dụng thành công" });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = "Role_Admin")]
        [Route("GetById_TuyenDung")]
        [HttpGet]
        public IActionResult getById(int id)
        {
            try
            {
                var query = _context.TuyenDungs.Find(id);
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
        [Route("Delete_TuyenDung")]
        [HttpDelete]
        public JsonResult deleteById(int id)
        {
            try
            {
                var query = _context.TuyenDungs.Find(id);
                if (query == null)
                {
                    return Json(new { message = "Không tìm thấy dữ liệu" });
                }
                _context.TuyenDungs.Remove(query);
                _context.SaveChanges();
                return Json(new { message = "Xóa thành công" });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [Route("Upload_Image")]
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "Uploads", "TuyenDung");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string filePath = Path.Combine(uploadsFolder, file.FileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return Ok(new { fileName = file.FileName });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
