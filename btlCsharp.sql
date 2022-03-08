CREATE DATABASE QuanLyCuaHangSach
USE QuanLyCuaHangSach
GO

--tạo bảng nxb và ràng buộc
CREATE TABLE tblNXB(
	sMaNXB VARCHAR(10) NOT NULL,
	sTenNXB NVARCHAR(25) UNIQUE NULL,
	sSDT VARCHAR(10) UNIQUE NULL,
	sDC NVARCHAR(255)NULL,
	CONSTRAINT PK_sMaNXB PRIMARY KEY(sMaNXB)
);

--tạo bảng sách và ràng buộc
CREATE TABLE tblSach(
	sMasach VARCHAR(10) NOT NULL,
	sTensach NVARCHAR(255) NULL,
	sMaNXB VARCHAR(10) NOT NULL,
	sTacgia NVARCHAR(255) NULL,
	sTheloai NVARCHAR(255) NULL,
	iSLSach INT DEFAULT 0 ,

	CONSTRAINT PK_sMasach PRIMARY KEY(sMasach),
	CONSTRAINT FK_Sach_NXB FOREIGN KEY(sMaNXB)
	REFERENCES tblNXB(sMaNXB),
	
	CONSTRAINT CHK_iSLSach CHECK (iSLSach>=0)
);

alter table tblSach
add constraint ucTensach UNIQUE (sTensach)

--tạo bảng nhân viên và ràng buộc
CREATE TABLE tblNhanVien(
	sMaNV VARCHAR(10) NOT NULL,
	sTenNV NVARCHAR(25) NULL,
	dNgaysinh DATE NULL,
	bGioitinh bit NULL,
	sDiachi NVARCHAR(255) NULL,
	sSDT VARCHAR(10) Unique NULL,
	fHSL FLOAT NULL,
	fPC FLOAT NULL,
	dNgayvaolam DATE NULL,

	CONSTRAINT PK_sMaNV PRIMARY KEY(sMaNV),
	CONSTRAINT CHK_fHSL CHECK (fHSL>0),
	CONSTRAINT CHK_fPC CHECK (fPC>0),
	CONSTRAINT CHK_dNgayvaolam CHECK (dNgayvaolam<=GETDATE()),
	CONSTRAINT CHK_dNgaysinh CHECK (dNgaysinh<=GETDATE())
);

alter table tblNhanVien
add CONSTRAINT  CHK_dTuoidilam CHECK (DATEDIFF(year,dNgaysinh,dNgayvaolam) >= 18)

--tạo hóa đơn và ràng buộc
CREATE TABLE tblHoaDonXuat(
	sMaHDX VARCHAR(10) NOT NULL,
	sMaNV VARCHAR(10) NULL,
	dNgayLap DATE NULL,

	CONSTRAINT PK_sMaHDX PRIMARY KEY(sMaHDX),
	CONSTRAINT FK_HoaDonX_NhanVien FOREIGN KEY(sMaNV)
	REFERENCES tblNhanVien(sMaNV),
	CONSTRAINT CHK_dNgayLapHDX CHECK (dNgayLap<=GETDATE())
);


--tạo bảng chi tiết hóa đơn và ràng buộc
CREATE TABLE tblChiTietHDX(
	sMaHDX VARCHAR(10) NOT NULL,
	sMasach VARCHAR(10) NOT NULL,
	iSL INT NULL,
	fDGban FLOAT NULL,

	CONSTRAINT PK_sMaHDX_sMasach PRIMARY KEY(sMaHDX,sMasach),
	CONSTRAINT CHK_iSLHDX CHECK (iSL>0),
	CONSTRAINT CHK_fDGban CHECK (fDGban>0),
	CONSTRAINT FK_ChiTietHDX_HoaDonXuat FOREIGN KEY(sMaHDX)
	REFERENCES tblHoaDonXuat(sMaHDX),
	CONSTRAINT FK_ChiTietHDX_Sach FOREIGN KEY(sMasach)
	REFERENCES tblSach(sMasach)
);
alter table tblChiTietHDX
add constraint ucHDXMS UNIQUE (sMaHDX,sMasach)


CREATE TABLE tblHoaDonNhap(
	sMaHDN VARCHAR(10) NOT NULL,
	sMaNV VARCHAR(10) NULL,
	dNgayLap DATE NULL,
	CONSTRAINT PK_sMaHDN PRIMARY KEY(sMaHDN),
	CONSTRAINT FK_HoaDonNhap_NhanVien FOREIGN KEY(sMaNV)
	REFERENCES tblNhanVien(sMaNV),
	CONSTRAINT CHK_dNgayLapHDN CHECK (dNgayLap<=GETDATE())
);


--tạo bảng chi tiết hóa đơn và ràng buộc
CREATE TABLE tblChiTietHDN(
	sMaHDN VARCHAR(10) NOT NULL,
	sMasach VARCHAR(10) NOT NULL,
	iSL INT NULL,
	fDGmua FLOAT NULL,

	CONSTRAINT PK_sMaHDN_sMasach PRIMARY KEY(sMaHDN,sMasach),
	CONSTRAINT CHK_iSLHDN CHECK (iSL>0),
	CONSTRAINT CHK_fDGmua CHECK (fDGmua>0),
	CONSTRAINT FK_ChiTietHDN_HoaDonNhap FOREIGN KEY(sMaHDN)
	REFERENCES tblHoaDonNhap(sMaHDN),
	CONSTRAINT FK_ChiTietHDN_Sach FOREIGN KEY(sMasach)
	REFERENCES tblSach(sMasach)
);

alter table tblChiTietHDN
add constraint ucHDNMS UNIQUE (sMaHDN,sMasach)
