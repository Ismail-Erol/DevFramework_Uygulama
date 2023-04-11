using DevFramework.Core.CrossCuttingConcerns.Security.Web;
using DevFramework.Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: Account
        public string Login(string username, string password)
        {
            var user = _userService.GetByUserNameAndPasswd(username, password);
            if (user != null)
            {
                // buradaki bilgiler normalde veritabanından alınması gerekir. şimdilik deneme amaçlı manuel oluşturuyoruz. 
                // normalde böyle bir kullanıcı veritabanında varsa bu şekilde method içerisine gödnerilir. 
                AuthenticationHelper.CreateAuthCookie(
                        new Guid(),
                        user.UserName,
                        user.Email,
                        DateTime.Now.AddDays(15),
                        _userService.GetUserRoles(user).Select(u=>u.RolesName).ToArray(),
                        false, 
                        user.FirstName, 
                        user.LastName
                        );
                return "User is authenticated";
            }
            return "User is Notttt authenticated"; // bu kısım deneme amaçlı!
        }
    }
}