
--proc them nxb
create procedure them_NXB
@MaNXB VARCHAR(10),
@TenNXB NVARCHAR(25),
@SDT VARCHAR(10),
@DC NVARCHAR(255)
AS
begin 
	INSERT INTO tblNXB VALUES (@MaNXB,@TenNXB,@SDT,@DC)
end

exec them_NXB '241',N'Kim Đồng','0696969669',N'Hà Nội'
select * from tblNXB

--proc xoa nxb
create procedure xoa_NXB
@MaNXB VARCHAR(10)
AS
begin 
	delete from tblNXB where (@MaNXB=sMaNXB)
end

exec xoa_NXB '241'


create procedure them_sach
@Masach VARCHAR(10),
@Tensach NVARCHAR(255),
@MaNXB VARCHAR(10),
@Tacgia NVARCHAR(255),
@Theloai NVARCHAR(255)
as 
begin 
	insert into tblSach values (@Masach,@Tensach,@MaNXB,@Tacgia,@Theloai,0)
end

exec them_sach '22',N'dark nhân tâm','241',N'hung',N'chúa hề'
delete from tblSach where sMasach = '21'
select * from tblSach

create procedure xoa_sach
@Masach VARCHAR(10)
as 
begin 
	delete from tblSach where (@Masach=sMasach)
end

exec xoa_sach '21'

create procedure sua_sach_theo_ma
@Masach VARCHAR(10),
@Tensach NVARCHAR(255)
as
begin 
	update tblSach
	set sTensach=@Tensach
	where sMasach=@Masach
end

create procedure sua_nxb_theo_ma
@Manxb VARCHAR(10),
@Tennxb NVARCHAR(25)
as
begin 
	update tblNXB
	set sTenNXB=@Tennxb
	where sMaNXB=@Manxb
end

select * from tblNXB

select * from tblSach

--thủ tục liên quan đến nhân viên

create proc procThemNhanVien
@MaNV VARCHAR(10),
@TenNV NVARCHAR(25),
@Ngaysinh DATE, 
@Gioitinh bit,
@Diachi NVARCHAR(255),
@SDT VARCHAR(10),
@HSL FLOAT,
@PC FLOAT,
@Ngayvaolam DATE
as
begin 
	insert into tblNhanVien values (@MaNV,@TenNV,@Ngaysinh,@Gioitinh,@Diachi,@SDT,@HSL,@PC,@Ngayvaolam)
end

exec procThemNhanVien '001',N'Hùng','3/20/1990',1,N'Hà Nội','0123456789',2,30000,'3/20/2012'
exec procThemNhanVien '002',N'Linh','3/20/1990',0,N'Hà Nội','0123456241',3,200000,'5/20/2012'

--luong co ban =1000000

CREATE VIEW vDanhSachNhanVien 
AS
with Luongcoban(luong) as (
	select 100000 as 'luong'
	)
SELECT sMaNV as N'Mã Nhân viên', sTenNV , dNgaysinh as N'Ngày sinh',
case bGioitinh  WHEN 1 THEN N'Nam' ELSE N'Nữ' END 
as N'Giới tính',sDiachi as N'Địa chỉ',
sSDT as N'Số điện thoại', fHSL as N'Hệ số lương',
fPC as N'Phụ Cấp', fHSL*luong+fPC as N'Lương',dNgayvaolam N'Ngày vào làm'
FROM tblNhanVien,Luongcoban

select * from vDanhSachNhanVien

create proc procSuaNhanVien
@MaNV VARCHAR(10),
@TenNV NVARCHAR(25),
@Ngaysinh DATE,
@Gioitinh bit,
@Diachi NVARCHAR(255),
@SDT VARCHAR(10),
@HSL FLOAT,
@PC FLOAT,
@Ngayvaolam DATE
as
begin 
	Update tblNhanVien
	Set sTenNV=@TenNV,dNgaysinh=@Ngaysinh,bGioitinh=@Gioitinh
	,sDiachi=@Diachi,sSDT=@SDT,fHSL=@HSL,fPC=@PC,dNgayvaolam=@Ngayvaolam
	where sMaNV=@MaNV
end

create proc procXoaNhanVien
@MaNV VARCHAR(10)
as
begin 
	delete from tblNhanVien
	where sMaNV=@MaNV
end

select * from vDanhSachNhanVien where sTenNV like N'%Hù%'


--thủ tục liên quan đến hóa đơn nhap

alter VIEW vDanhSachHoaDonNhap
AS
SELECT sMaHDN as N'Mã hóa đơn', sMaNV as N'Mã nhân viên', 
(
	select sTenNV
	FROM  tblNhanVien 
	where tblNhanVien.sMaNV=tblHoaDonNhap.sMaNV
) as N'Tên nhân viên',
dNgayLap N'Ngày lập',isnull((
	select SUM(iSL*fDGmua)
	FROM  tblChiTietHDN
	where sMaHDN=tblHoaDonNhap.sMaHDN
	GROUP BY sMaHDN
),0) as N'Tổng tiền'
FROM tblHoaDonNhap 

select *from vDanhSachHoaDonNhap


create proc procThemHDN
@MaHDN VARCHAR(10),
@MaNV VARCHAR(10),
@NgayLap DATE
as
	insert into tblHoaDonNhap values (@MaHDN,@MaNV,@NgayLap)

execute procThemHDN 'HDN001','001','03/04/2019'
execute procThemHDN 'HDN002','002','03/04/2018'

alter proc procSuaHDN
@MaHDN VARCHAR(10),
@MaNV VARCHAR(10),
@NgayLap DATE
as
	update tblHoaDonNhap set sMaNV=@MaNV,dNgayLap=@NgayLap where  sMaHDN = @MaHDN

create proc procXoaHDN
@MaHDN VARCHAR(10)
as
	delete from tblHoaDonNhap where  sMaHDN=@MaHDN

exec procXoaHDN N'HDN001'
select * from tblHoaDonNhap
select * from tblSach

-- proc chi tiet hd nhap

select * from tblChiTietHDN
select * from tblHoaDonNhap
select * from tblSach

create proc procThemChiTietHDN
@MaHDN VARCHAR(10),
@Masach VARCHAR(10),
@SL INT,
@DGmua FLOAT
as
	insert tblChiTietHDN values (@MaHDN,@Masach,@SL,@DGmua)

exec procThemChiTietHDN 'HDN001','22',30,4000


create view vDanhSachChiTietHoaDonNhap
as
select sMaHDN, sMasach, 
(
	select sTensach
	FROM  tblSach 
	where tblSach.sMasach=tblChiTietHDN.sMasach
) as N'Ten sach',
iSL,fDGmua,
(iSL*fDGmua) as 'tong tien'
from tblChiTietHDN



create proc proc_ThemChiTietHDN
@MaHDN VARCHAR(10),
@Masach VARCHAR(10),
@SL INT,
@DGmua FLOAT
as
begin	
	insert into tblChiTietHDN values (@MaHDN,@Masach,@SL,@DGmua)
end

select*from tblHoaDonNhap
select*from tblSach

exec proc_ThemChiTietHDN 'HDN002', '22',10,5000

create proc proc_SuaChiTietHDN
@MaHDN VARCHAR(10),
@Masach VARCHAR(10),
@SL INT,
@DGmua FLOAT
as
begin	
	update tblChiTietHDN set iSL=@SL,fDGmua=@DGmua
	where @MaHDN=sMaHDN and @Masach=sMasach
end

exec  proc_SuaChiTietHDN 'HDN002', '22',10,5000

create proc proc_XoaChiTietHDN
@MaHDN VARCHAR(10),
@Masach VARCHAR(10)
as
begin	
	delete tblChiTietHDN
	where @MaHDN=sMaHDN and @Masach=sMasach
end

