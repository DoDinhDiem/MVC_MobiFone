using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobifone_DATN.Models;

namespace Mobifone_DATN.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("Admin")]
    [Route("Admin/HoaDon")]
    public class HoaDonController : Controller
    {
        private readonly DATN_MobifoneContext _context;

        public HoaDonController(DATN_MobifoneContext context)
        {
            _context = context;
        }
        [Route("")]
        [HttpGet]
        public IActionResult HoaDon()
        {
            return View();
        }

        [Authorize(Roles = "Role_Admin, Role_User")]
        [Route("Search_HoaDon")]
        [HttpGet]
        public IActionResult Search([FromQuery] string? title, int page = 1, int pageSize = 10)
        {
            try
            {
                var query = _context.HoaDonXuats.AsQueryable();

                if (!string.IsNullOrEmpty(title))
                {
                    query = query.Where(l => l.HoTen.Contains(title));
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
        [Route("Update_HoaDon")]
        [HttpPut]
        public JsonResult update([FromBody] HoaDonXuat model)
        {
            try
            {
                var query = _context.HoaDonXuats.Find(model.Id);
                if (query == null)
                {
                    return Json(new { message = "Không tìm thấy dữ liệu" });
                }
                query.TrangThaiDonHang = model.TrangThaiDonHang;
                _context.SaveChanges();
                return Json(new { message = "Cập nhập hóa đơn thành công" });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = "Role_Admin, Role_User")]
        [Route("GetById_HoaDon/{id}")]
        [HttpGet]
        public IActionResult getById(int id)
        {
            try
            {
                var query = _context.HoaDonXuats.Where(x => x.Id == id)
                    .Select(x => new
                    {
                        id = x.Id,
                        hoTen = x.HoTen,
                        soDienThoai = x.SoDienThoai,
                        diaChi = x.DiaChi,
                        ghiChu = x.GhiChu,
                        trangThaiDonHang = x.TrangThaiDonHang,
                        tongTien = x.TongTien,
                        createdAt = x.CreatedAt,
                        listChiTiet = _context.ChiTietHoaDons.
                                                    Where(t => t.HoaDonId == x.Id).Select(t => new
                                                    {
                                                        simSo = t.SimSo.SoThueBao,
                                                        giaBan = t.GiaBan
                                                    }).ToList()

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
    }
}
