using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobifone_DATN.Models;

namespace Mobifone_DATN.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("Admin")]
    [Route("Admin/TinTuc")]
    public class TinTucController : Controller
    {
        private readonly DATN_MobifoneContext _context;
        public static IWebHostEnvironment _environment;
        public TinTucController(DATN_MobifoneContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        [Route("")]
        [HttpGet]
        public IActionResult TinTuc()
        {
            return View();
        }

        [Authorize(Roles = "Role_Admin, Role_User")]
        [Route("Search_TinTuc")]
        [HttpGet]
        public IActionResult Search([FromQuery] string? title, int page = 1, int pageSize = 10)
        {
            try
            {
                var query = _context.TinTucs.AsQueryable();

                if (!string.IsNullOrEmpty(title))
                {
                    query = query.Where(l => l.TieuDe.Contains(title));
                }
                var totalItems = query.Count();

                var list = query.Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .Select(x => new
                                {
                                    id = x.Id,
                                    tieuDe = x.TieuDe,
                                    noiDung = x.NoiDung,
                                    image = x.Image,
                                    nguoiViet = x.NguoiVietNavigation.HoTen,
                                })
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
        [Route("Creat_TinTuc")]
        [HttpPost]
        public JsonResult create([FromBody] TinTuc model)
        {
            try
            {
                _context.TinTucs.Add(model);
                _context.SaveChanges();
                return Json(new { message = "Thêm tin tức thành công" });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = "Role_Admin, Role_User")]
        [Route("Update_TinTuc")]
        [HttpPut]
        public JsonResult update([FromBody] TinTuc model)
        {
            try
            {
                var query = _context.TinTucs.Find(model.Id);
                if (query == null)
                {
                    return Json(new { message = "Không tìm thấy dữ liệu" });
                }
                query.TieuDe = model.TieuDe;
                query.NoiDung = model.NoiDung;
                query.Image = model.Image;
                _context.SaveChanges();
                return Json(new { message = "Cập nhập tin tức thành công" });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = "Role_Admin, Role_User")]
        [Route("GetById_TinTuc")]
        [HttpGet]
        public IActionResult getById(int id)
        {
            try
            {
                var query = _context.TinTucs.Find(id);
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
        [Route("Delete_TinTuc")]
        [HttpDelete]
        public JsonResult deleteById(int id)
        {
            try
            {
                var query = _context.TinTucs.Find(id);
                if (query == null)
                {
                    return Json(new { message = "Không tìm thấy dữ liệu" });
                }
                _context.TinTucs.Remove(query);
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
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "Uploads", "TinTuc");
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
