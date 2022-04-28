﻿
using Quanlicaan.Models.Session;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Quanlicaan.Controllers
{
    public class LoginController : Controller
    {
        string connectionString = @"Data Source=ADMIN-PC;Initial Catalog=QuanLiCaAn;Integrated Security=True";

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
            SqlConnection conn = new SqlConnection(connectionString);
            {

                //kiem tra ten dang nhap va mat khau ok
                string sqlQuery = "select * from NhanVien where username ='" + username + "' and upassword = '" + password + "'";

                SqlCommand cmd = new SqlCommand(sqlQuery, conn);

                userSession us = new userSession();

                conn.Open();
                cmd.Connection = conn;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    us.HoTen = dr["HoTen"].ToString();
                    us.ID = Convert.ToInt32(dr["ID"]);
                    us.IDRole = Convert.ToInt32(dr["IDRole"]);
                    us.RoleRegist = dr["RoleRegist"].ToString();
                    Session["user"] = us;

                    conn.Close();
                    Response.Write("<script>alert('Login sucess')</script>");
               
                    return Redirect("/Home/Home");


                }

                else
                {
                    conn.Close();
                    return Content("<script language='javascript' type='text/javascript'>alert(' Đăng nhập thất bại! Vui lòng đăng nhập lại !');</script>");



                    //return RedirectToAction("Index", new { thongBao = "tên đăng nhập và mật khẩu không đúng" });
                }



            }


        }
    }
}