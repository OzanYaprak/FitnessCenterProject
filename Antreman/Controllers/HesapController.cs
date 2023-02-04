using Antreman.Data;
using Antreman.Helpers;
using Antreman.Models;
using Antreman.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Antreman.Controllers
{
    public class HesapController : Controller
    {
        private readonly antremanDBContext _context;

        public HesapController(antremanDBContext context)
        {
            _context = context;
        }

        public IActionResult Giris()
        {
            LoginViewModel x = new LoginViewModel();
            return View(x);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Giris([Bind("Emaill, Passwordd")] LoginViewModel userr)
        {
            if (ModelState.IsValid)
            {
                ClaimsIdentity identityy = null;
                bool isAuthenticated = false;
                Userr userr = await _context.Userrs.Include(a => a.Rolee).FirstOrDefaultAsync(b => b.Email == userr.Email && b.Password == userr.Passwordd);

                if (userr = null)
                {
                    ModelState.AddModelError("", "Kullanıcı Bulunamadı");
                    return View(userr);
                }

                identityy = new ClaimsIdentity
                    (new[]
                            {
                                new Claim(ClaimTypes.Sid,userr.UserrID.ToString()),
                                new Claim(ClaimTypes.Email,userr.Emaill),
                                new Claim(ClaimTypes.Role,userr.Rolee.RoleeName),
                            }, CookieAuthenticationDefaults.AuthenticationScheme
                    );

                isAuthenticated = true;
                if (isAuthenticated)
                {
                    var claimss = new ClaimsPrincipal(identityy);
                    var loginn = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimss,

                        new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTime.Now.AddMinutes(15)
                        }

                        );

                    if (userr.Rolee.RoleeName == "Aday")
                    {
                        return Redirect("~/Hesap/EpostaOnayHatirlatmasi");
                    }
                    else if (userr.Rolee.RoleeName == "Uye")
                    {
                        return RedirectToAction("", "");
                    }
                    else if (userr.Rolee.RoleeName == "Admin")
                    {
                        return Redirect("~/AdminAnasayfa/Index");
                    }
                    else if (userr.Rolee.RoleeName == "Supervisor")
                    {
                        return Redirect("~/AdminAnasayfa/Index");
                    }
                    else
                    {
                        return Redirect("~/Home/Index");
                    }
                }
                return View();
            }
            return View(userr);
        }

        public async Task<IActionResult> Aktivasyon(string kkk)
        {
            string emaill = Criyptoo.Decrypted(kkk);

            Userr userr = await _context.Userrs.FirstOrDefaultAsync(a => a.Emaill == emaill);
            userr.RoleeID = 2;
            _context.Userrs.Update(userr);
            await _context.SaveChangesAsync();

            return View();
        }

        [Authorize(Roles = "Aday")]
        public IActionResult EpostaOnayHatirlatmasi()
        {
            return View();
        }

        public IActionResult KayitOl()
        {
            Userr userr = new Userr();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> KayitOl([Bind("Emaill", "Passwordd", "PasswordRepeatt")] Userr userr)
        {
            userr.RoleeID = 1;
            Userr selectedUserr = await _context.Userrs.FirstOrDefaultAsync(a => a.Emaill == userr.Emaill);

            if (selectedUserr!=null)
            {
                ModelState.AddModelError("", "Eposta zaten kullanımda.");
            }

            if (ModelState.IsValid)
            {
                await _context.Userrs.AddAsync(userr);
                await _context.SaveChangesAsync();

                EmailOperations.SendActivationMail(userr.Emaill);

                return RedirectToAction("Giris", "Hesap");   
            }
            return View(userr);
        }
        public IActionResult SifremiUnuttum() 
        {
            return View(); 
        }

        public IActionResult Cikis() 
        {
            var giris = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("", "");
        }

    }
}
