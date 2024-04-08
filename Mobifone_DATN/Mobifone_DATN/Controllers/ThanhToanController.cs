using Microsoft.AspNetCore.Mvc;
using Mobifone_DATN.Models;

namespace Mobifone_DATN.Controllers
{
    public class ThanhToanController : Controller
    {
        private readonly DATN_MobifoneContext _context;
        public ThanhToanController(DATN_MobifoneContext context)
        {
            _context = context;
        }

        [Route("ThanhToan")]
        public IActionResult ThanhToan()
        {
            return View();
        }

        [Route("Create_HoaDonXuat")]
        [HttpPost]
        public async Task<IActionResult> CreateHoaDonBan([FromBody] HoaDonXuat model)
        {
            try
            {
                _context.HoaDonXuats.Add(model);


                var newHoaDon = new List<ChiTietHoaDon>();

                foreach (var cthd in model.ChiTietHoaDons)
                {
                    var sanPham = await _context.SimSos.FindAsync(cthd.SimSoId);
                    if (sanPham == null)
                    {
                        return NotFound(new { message = "Không tìm thấy sản phẩm" });
                    }

                    if (!sanPham.TrangThai)
                    {
                        return BadRequest(new { message = "Sim số đã bán" });
                    }

                    sanPham.TrangThai = false;

                    var ct = new ChiTietHoaDon
                    {
                        HoaDonId = model.Id,
                        SimSoId = cthd.SimSoId,
                        GiaBan = cthd.GiaBan
                    };
                    newHoaDon.Add(ct);
                }

                int totalAmount = model.ChiTietHoaDons.Sum(ct => ct.GiaBan) ?? 0;
                model.TongTien = totalAmount;

                await _context.SaveChangesAsync();
                return Ok(new
                {
                    message = "Đặt hàng thành công!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
