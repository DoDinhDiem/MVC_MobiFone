using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobifone_DATN.Models;

namespace Mobifone_DATN.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("Admin")]
    [Route("Admin/Slide")]
    public class SlideController : Controller
    {
        private readonly DATN_MobifoneContext _context;
        public static IWebHostEnvironment _environment;

        public SlideController(DATN_MobifoneContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [Route("")]
        public IActionResult Slide()
        {
            return View();
        }

        [Authorize(Roles = "Role_Admin")]
        [Route("Search_Slide")]
        [HttpGet]
        public IActionResult Search([FromQuery] int page = 1, int pageSize = 10)
        {
            try
            {
                var query = _context.Slides.AsQueryable();

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
        [Route("Creat_Slide")]
        [HttpPost]
        public JsonResult create([FromBody] Slide model)
        {
            try
            {
                _context.Slides.Add(model);
                _context.SaveChanges();
                return Json(new { message = "Thêm slide thành công" });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = "Role_Admin")]
        [Route("Update_Slide")]
        [HttpPut]
        public JsonResult update([FromBody] Slide model)
        {
            try
            {
                var query = _context.Slides.Find(model.Id);
                if (query == null)
                {
                    return Json(new { message = "Không tìm thấy dữ liệu" });
                }
                query.Image = model.Image;
                _context.SaveChanges();
                return Json(new { message = "Cập nhập slide thành công" });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = "Role_Admin")]
        [Route("GetById_Slide")]
        [HttpGet]
        public IActionResult getById(int id)
        {
            try
            {
                var query = _context.Slides.Find(id);
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
        [Route("Delete_Slide")]
        [HttpDelete]
        public JsonResult deleteById(int id)
        {
            try
            {
                var query = _context.Slides.Find(id);
                if (query == null)
                {
                    return Json(new { message = "Không tìm thấy dữ liệu" });
                }
                _context.Slides.Remove(query);
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
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "Uploads", "Slide");
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
