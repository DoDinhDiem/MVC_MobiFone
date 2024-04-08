using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobifone_DATN.Models;

namespace Mobifone_DATN.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("Admin")]
    [Route("Admin/LienHe")]
    public class LienHeController : Controller
    {
        private readonly DATN_MobifoneContext _context;
        public static IWebHostEnvironment _environment;
        public LienHeController(DATN_MobifoneContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        [Route("")]
        [HttpGet]
        public IActionResult LienHe()
        {
            return View();
        }

        [Authorize(Roles = "Role_Admin")]
        [Route("Search_LienHe")]
        [HttpGet]
        public IActionResult Search([FromQuery] string? fullname,  int page = 1, int pageSize = 10)
        {
            try
            {
                var query = _context.LienHes.AsQueryable();

                if (!string.IsNullOrEmpty(fullname))
                {
                    query = query.Where(l => l.Fullname.Contains(fullname));
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
        [Route("Creat_LienHe")]
        [HttpPost]
        public JsonResult create([FromBody] LienHe model)
        {
            try
            {
                _context.LienHes.Add(model);
                _context.SaveChanges();
                return Json(new { message = "Thêm liên hệ thành công" });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = "Role_Admin")]
        [Route("Update_LienHe")]
        [HttpPut]
        public JsonResult update([FromBody] LienHe model)
        {
            try
            {
                var query = _context.LienHes.Find(model.Id);
                if (query == null)
                {
                    return Json(new { message = "Không tìm thấy dữ liệu" });
                }
                query.Fullname = model.Fullname;
                query.DiaChi = model.DiaChi;
                query.Phone = model.Phone;
                query.Map = model.Map;
                query.Image = model.Image;  
                _context.SaveChanges();
                return Json(new { message = "Cập nhập liên hệ thành công" });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = "Role_Admin")]
        [Route("GetById_LienHe")]
        [HttpGet]
        public IActionResult getById(int id)
        {
            try
            {
                var query = _context.LienHes.Find(id);
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
        [Route("Delete_LienHe")]
        [HttpDelete]
        public JsonResult deleteById(int id)
        {
            try
            {
                var query = _context.LienHes.Find(id);
                if (query == null)
                {
                    return Json(new { message = "Không tìm thấy dữ liệu" });
                }
                _context.LienHes.Remove(query);
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
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "Uploads", "LienHe");
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
