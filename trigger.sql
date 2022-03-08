
-- trigger chi tiet HDN va sach
create trigger trInsertChiTietHDN_Sach
on tblChiTietHDN
for insert
as 
begin
	declare @sosach INT,@masach INT
	select @sosach=iSL,@masach=sMasach from inserted
	IF EXISTS(SELECT * FROM tblSach WHERE sMasach = @masach)
		BEGIN
			UPDATE tblSach
			SET iSLSach = iSLSach + @sosach
			WHERE sMasach = @masach
		END
	ELSE
		BEGIN
			print N'Không tồn tại cuốn sách này'
			ROLLBACK TRAN
		END
end


create trigger trDeleteChiTietHDN_Sach
on tblChiTietHDN
for delete
as 
begin
	declare @sosach INT,@masach INT
	select @sosach=iSL,@masach=sMasach from deleted
	IF EXISTS(SELECT * FROM tblSach WHERE sMasach = @masach) and @sosach <= (SELECT iSLSach FROM tblSach WHERE sMasach = @masach)
		BEGIN
			UPDATE tblSach
			SET iSLSach = iSLSach - @sosach
			WHERE sMasach = @masach
		END
	ELSE
		BEGIN
			print N'Không thể xóa vì đã không còn đủ sách này'
			ROLLBACK TRAN
		END
end


CREATE TRIGGER UpdateChiTietHDN_Sach
ON tblChiTietHDN
FOR UPDATE
AS
BEGIN

	DECLARE @slmoi int, @slcu int, @masach VARCHAR(10)
	SELECT @slmoi = iSL,@masach=sMasach FROM inserted
	SELECT @slcu = iSL FROM deleted
	

	IF EXISTS(SELECT * FROM tblSach WHERE sMasach = @masach)
	and  (SELECT iSLSach FROM tblSach WHERE sMasach = @masach)-@slcu+@slmoi>=0
		BEGIN
			UPDATE tblSach
			SET iSLSach = iSLSach - @slcu+@slmoi
			WHERE sMasach = @masach
		END
	ELSE
		BEGIN
			print N'Không thể sửa được'
			ROLLBACK TRAN
		END
END
