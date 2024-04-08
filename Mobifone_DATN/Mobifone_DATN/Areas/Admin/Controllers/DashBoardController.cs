using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobifone_DATN.Models;

namespace Mobifone_DATN.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("Admin")]
    [Route("Admin/Dashboard")]
    public class DashBoardController : Controller

    {
        private readonly DATN_MobifoneContext _context;
        public DashBoardController(DATN_MobifoneContext context)
        {
            _context = context;
        }
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("CountDonHang")]
        [HttpGet]
        public async Task<ActionResult<int>> GetCountDonHang()
        {
            try
            {
                var query = _context.HoaDonXuats.Count();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("CountDoanhThu")]
        [HttpGet]
        public async Task<ActionResult<int>> GetCountDoanhThu()
        {
            try
            {
                var query = _context.HoaDonXuats.Where(x => x.TrangThaiDonHang == "Giao hàng thành công").Sum(x => x.TongTien);
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("CountTinTuc")]
        [HttpGet]
        public async Task<ActionResult<int>> GetCountTinTuc()
        {
            try
            {
                var query = _context.TinTucs.Count();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("CountNhanVien")]
        [HttpGet]
        public async Task<ActionResult<int>> GetCountNhanVien()
        {
            try
            {
                var query = _context.NhanViens.Count();
                return Ok(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("ThongKeTheoThang/{year}")]
        [HttpGet]
        public async Task<IActionResult> GetThongKeTheoThang(int year)
        {
            try
            {
                var query = Enumerable.Range(1, 12)
                    .Select(month => new
                    {
                        Thang = month,
                        TongTien = _context.HoaDonXuats
                            .Where(hd => hd.CreatedAt.HasValue &&
                                         hd.CreatedAt.Value.Year == year &&
                                         hd.CreatedAt.Value.Month == month &&
                                         hd.TrangThaiDonHang == "Giao hàng thành công")
                            .Sum(hd => hd.TongTien)
                    })
                    .ToList();
                var tongTienNam = _context.HoaDonXuats.Where(hd => hd.CreatedAt.HasValue &&
                        hd.CreatedAt.Value.Year == year &&
                        hd.TrangThaiDonHang == "Giao hàng thành công").Sum(hd => hd.TongTien);
                var result = new
                {
                    ThongKeThang = query,
                    TongTienNam = tongTienNam
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
