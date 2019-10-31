/*using Discord.OAuth2;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Energize.Web.Controllers
{
    [Controller]
    public class OAuthController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("login/music")]
        public IActionResult MusicLogin()
            => this.LoginAndRedirect("music");

        [AllowAnonymous]
        [HttpGet("login/admin")]
        public IActionResult AdminLogin()
            => this.LoginAndRedirect("admin");

        public IActionResult LoginAndRedirect(string uri)
            => this.Challenge(new AuthenticationProperties
            {
                RedirectUri = $"/{uri}",
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1),
            }, DiscordDefaults.AuthenticationScheme);

        [Authorize]
        [HttpGet("logout")]
        public IActionResult Logout()
            =>  this.SignOut(new AuthenticationProperties
            {
                RedirectUri = "/"
            }, CookieAuthenticationDefaults.AuthenticationScheme);

        [AllowAnonymous]
        public IActionResult Discord()
            => this.Redirect("music");
    }
}*/