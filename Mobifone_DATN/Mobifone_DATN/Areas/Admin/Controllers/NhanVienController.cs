using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobifone_DATN.Models;
using Mobifone_DATN.Models.Dto;

namespace Mobifone_DATN.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("Admin")]
    [Route("Admin/NhanVien")]
    public class NhanVienController : Controller
    {
        private readonly DATN_MobifoneContext _context;

        public NhanVienController(DATN_MobifoneContext context)
        {
            _context = context;
        }
        [Route("")]
        [HttpGet]
        public IActionResult NhanVien()
        {
            return View();
        }

        [Authorize(Roles = "Role_Admin")]
        [Route("Search_NhanVien")]
        [HttpGet]
        public IActionResult Search([FromQuery] string? title, int page = 1, int pageSize = 10)
        {
            try
            {
                var query = _context.NhanViens.Include(x => x.TaiKhoan).AsQueryable();

                if (!string.IsNullOrEmpty(title))
                {
                    query = query.Where(l => l.HoTen.Contains(title));
                }

                var totalItems = query.Count();

                var list = query.Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .Select(x=> new
                                {
                                    id = x.Id,
                                    userName = x.TaiKhoan.UserName,
                                    email = x.TaiKhoan.Email,
                                    quyen = x.TaiKhoan.Role.TenRole,
                                    hoTen = x.HoTen,
                                    gioiTinh = x.GioiTinh,
                                    ngaySinh = x.NgaySinh,
                                    diaChi = x.DiaChi,
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

        [Authorize(Roles = "Role_Admin")]
        [Route("Creat_NhanVien")]
        [HttpPost]
        public JsonResult Create([FromBody] TaiKhoanNhanVien model)
        {
            try
            {
                var existingEmail = _context.TaiKhoans.FirstOrDefault(x => x.Email == model.Email);
                if (existingEmail != null)
                {
                    return Json(new { message = "Email đã tồn tại" });
                }

                var existingUserName = _context.TaiKhoans.FirstOrDefault(x => x.UserName == model.UserName);
                if (existingUserName != null)
                {
                    return Json(new { message = "UserName đã tồn tại" });
                }
                var taikhoan = new TaiKhoan()
                {
                    RoleId = model.RoleId,
                    UserName = model.UserName,
                    Email = model.Email,
                    PassWord = model.PassWord,
                };

                _context.TaiKhoans.Add(taikhoan);
                _context.SaveChanges();

                var nhanvien = new NhanVien()
                {
                    TaiKhoanId = taikhoan.Id,
                    HoTen = model.HoTen,
                    GioiTinh = model.GioiTinh,
                    NgaySinh = model.NgaySinh,
                    DiaChi = model.DiaChi,
                };
                _context.NhanViens.Add(nhanvien);
                _context.SaveChanges();
                return Json(new { message = "Thêm nhân viên thành công" });
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Role_Admin")]
        [Route("Update_NhanVien")]
        [HttpPut]
        public JsonResult update([FromBody] TaiKhoanNhanVien model)
        {
            try
            {

                var query = _context.NhanViens.Find(model.Id);
                var result = _context.TaiKhoans.Find(query.TaiKhoanId);
                if (query == null)
                {
                    return Json(new { message = "Không tìm thấy dữ liệu" });
                }

                result.RoleId = model.RoleId;
                query.HoTen = model.HoTen;
                query.GioiTinh = model.GioiTinh;
                query.NgaySinh = model.NgaySinh;
                query.DiaChi = model.DiaChi;
                _context.SaveChanges();
                return Json(new { message = "Cập nhập nhân viên thành công" });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = "Role_Admin")]
        [Route("GetById_NhanVien")]
        [HttpGet]
        public IActionResult getById(int id)
        {
            try
            {
                var query = _context.NhanViens.Where(x => x.Id == id)
                    .Select(x => new
                    {
                        id = x.Id,
                        roleId = x.TaiKhoan.RoleId,
                        hoTen = x.HoTen,
                        gioiTinh = x.GioiTinh,
                        ngaySinh = x.NgaySinh,
                        diaChi = x.DiaChi,
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

        [Authorize(Roles = "Role_Admin")]
        [Route("Delete_NhanVien")]
        [HttpDelete]
        public JsonResult deleteById(int id)
        {
            try
            {
                var query = _context.NhanViens.Find(id);
                if (query == null)
                {
                    return Json(new { message = "Không tìm thấy dữ liệu" });
                }
                _context.NhanViens.Remove(query);
                _context.SaveChanges();
                return Json(new { message = "Xóa thành công" });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = "Role_Admin")]
        [Route("GetAllRole")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var query = _context.Roles.ToList();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
