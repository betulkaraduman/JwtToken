using JwtApp_Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace JwtApp_Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LogIn()
        {
            return View(new UserLoginModel());
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(UserLoginModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5216/api/Auth/SignIn", jsonData);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(data, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(tokenModel?.Token);
                if (token != null)
                {
                    var roles = token.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value);
                    if (roles.Contains("Admin") || roles.Contains("Member"))
                    {
                        var claims = token.Claims.ToList();
                        claims.Add(new Claim("accessToken", tokenModel?.Token==null?"":tokenModel.Token));


                        ClaimsIdentity identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProperty = new AuthenticationProperties { ExpiresUtc = tokenModel?.ExpireDate, IsPersistent = true };
                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authProperty);
                        if (roles.Contains("Admin"))
                            return RedirectToAction("AdminPage", "Home");
                        else
                            return RedirectToAction("MemberPage", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Username or password error");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username or password error");
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", "Username or password error");
                return View(model);

            }
        }
        public IActionResult Logout() { return View(); }
        public IActionResult AccessDenied() { return View(); }
    }
}
