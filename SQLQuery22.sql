USE [QuanLiCaAn]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Login_Session]    Script Date: 21/04/2022 3:10:37 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[Sp_Login_Session]
@username nvarchar(50), 
@password nvarchar(50)
as 
begin
 SELECT NhanVien.ID, PhongBan.ID as IDPhongBan, NhanVien.hoTen, TenPB, NhanVien.username from NhanVien, PhongBan where username = @username and upassword = @password and PhongBan.ID = NhanVien.IDPhongBan
 end
 