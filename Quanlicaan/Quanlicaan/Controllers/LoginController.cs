﻿using Quanlicaan.Models;
using Quanlicaan.Models.Session;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Configuration;


namespace Quanlicaan.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel login)
        {
            
            UserModel user = new UserModel();
          //  bool check = user.CheckLogin(login);
            UserSession  us = user.GetNhanVienLogin(login);

            if (us!= null)
            {
                Session["UserSession"] = us;
                return RedirectToAction("Home", "Home");
            }
            else
            {
                Response.Write("<script>alert('Đăng nhập không thành công')</script>");
                ModelState.AddModelError("","Thông tin tài khoản hoặc mật khẩu không đúng" );
                return View("Index");
            }
            
        }

        [HttpPost]
        public ActionResult logOut()
        {
            
            Session.RemoveAll();
            return RedirectToAction("Index");
        }
    }
}