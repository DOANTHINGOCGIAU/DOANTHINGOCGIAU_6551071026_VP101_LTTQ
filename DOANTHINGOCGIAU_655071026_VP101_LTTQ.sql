IF DB_ID(N'DuLieu') IS NULL CREATE DATABASE DuLieu;
GO;
USE DuLieu;
GO;
IF OBJECT_ID(N'dbo.CongViec',N'U') IS NOT NULL DROP TABLE dbo.CongViec;
GO
CREATE TABLE dbo.CongViec (
	MaCongViec NVARCHAR(10) PRIMARY KEY,
	TenCongViec nText NOT NULL,
	LuongThang NVARCHAR(8) NOT NULL 
		CHECK(LuongThang >0)
);

