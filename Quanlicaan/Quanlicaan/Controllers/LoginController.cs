﻿using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Model2"].ConnectionString);
        // GET: Login
        [HttpGet]
        public ActionResult Index(string thongBao)
        {
            ViewBag.thongBao = thongBao;
            return View();
        }
        [HttpPost]
        public ActionResult DangNhapHeThong(string username, string password)
        {
            //kiem tra ten dang nhap va mat khau ok
            string sqlQuery = "select 1 from NhanVien where username ='" + username + "' and upassword = '" + password + "'";

            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.Connection = con;

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                Response.Write("<script>alert('Login sucess')</script>");
                Session["username"] = username;
                return Redirect("/Home/Home");
               

            }
           
            con.Close();
            Response.Write("<script>alert('Đăng nhập thất bại')</script>");
            return RedirectToAction("Index", new { thongBao = "tên đăng nhập và mật khẩu không đúng" });
        }

    
    }
}