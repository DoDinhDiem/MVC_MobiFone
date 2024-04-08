using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Mobifone_DATN.Dto;
using Mobifone_DATN.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mobifone_DATN.Controllers
{
    public class AccountController : Controller
    {
        private readonly DATN_MobifoneContext _context;
        private AppSetting _appSetting;
        public AccountController(DATN_MobifoneContext context, IOptions<AppSetting> appSetting)
        {
            _context = context;
            _appSetting = appSetting.Value;
        }
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("LoginAdmin")]
        [HttpPost]
        public async Task<IActionResult> LoginAdmin([FromBody] TaiKhoan user)
        {
            var UserName = user.UserName;
            var PassWord = user.PassWord;

            var users = _context.TaiKhoans
                                 .Where(x => x.UserName == UserName)
                                 .Join(
                                     _context.NhanViens,
                                     us => us.Id,
                                     ns => ns.TaiKhoanId,
                                     (us, ns) => new
                                     {
                                         UserName = us.UserName,
                                         PassWord = us.PassWord,
                                         HoTen = ns.HoTen,
                                         Role = us.Role.TenRole,
                                         UserId = ns.Id
                                     }
                                 ).SingleOrDefault();
            if (users == null)
            {
                return Ok(new
                {
                    message = "Tài khoản không đúng"
                });
            }
            if (users.PassWord != user.PassWord)
            {
                return Ok(new
                {
                    message = "Mật khẩu không đúng"
                });
            }


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, users.UserName.ToString()),
                    new Claim(ClaimTypes.Role, users.Role),
                    new Claim("UserId", users.UserId.ToString()),
                    new Claim("HoTen", users.HoTen.ToString()),

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tmp = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(tmp);
            return Ok(new
            {
                AccessToken = token
            });
        }
    }
}
