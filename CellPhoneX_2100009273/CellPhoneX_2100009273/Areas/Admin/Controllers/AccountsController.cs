using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Web.Security;
using CellPhoneX_2100009273.Models;
using System.Security.Cryptography;

namespace CellPhoneX_2100009273.Areas.Admin.Controllers
{
    public class AccountsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Accounts
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            using (DBContext context = new DBContext())
            {
                model.UserPassword = GetMD5(model.UserPassword);
                bool IsValidUser = context.Users.Any(user => user.UserName.ToLower() ==
                model.UserName.ToLower() && user.UserPassword == model.UserPassword);

                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    bool isAdmin = Roles.IsUserInRole(model.UserName, "Admin");

                    if (isAdmin)
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", new { area = "" });
                    }

                }
                ModelState.AddModelError("LoginError", "invalid UserName or Password");
                return View();
            }
        }

        public ActionResult Signup()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Signup(User model)
        {
            using (DBContext context = new DBContext())
            {
                model.UserPassword = GetMD5(model.UserPassword);
                context.Users.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login", "Accounts");
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = ""});
        }


        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}