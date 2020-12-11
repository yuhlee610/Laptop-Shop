USE [master]
GO
/****** Object:  Database [DBLaptop]    Script Date: 12/11/2020 5:51:15 PM ******/
CREATE DATABASE [DBLaptop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBLaptop', FILENAME = N'C:\Program Files\Microsoft SQL Server 2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\DBLaptop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBLaptop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server 2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\DBLaptop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DBLaptop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBLaptop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBLaptop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBLaptop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBLaptop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBLaptop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBLaptop] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBLaptop] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DBLaptop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBLaptop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBLaptop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBLaptop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBLaptop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBLaptop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBLaptop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBLaptop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBLaptop] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DBLaptop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBLaptop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBLaptop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBLaptop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBLaptop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBLaptop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBLaptop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBLaptop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBLaptop] SET  MULTI_USER 
GO
ALTER DATABASE [DBLaptop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBLaptop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBLaptop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBLaptop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBLaptop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBLaptop] SET QUERY_STORE = OFF
GO
USE [DBLaptop]
GO
/****** Object:  UserDefinedFunction [dbo].[vaValidEmail]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[vaValidEmail](@EMAIL varchar(100))
RETURNS bit as
BEGIN     
  DECLARE @bitRetVal as Bit
  IF (@EMAIL <> '' AND @EMAIL NOT LIKE '_%@__%.__%')
     SET @bitRetVal = 0  -- Invalid
  ELSE 
    SET @bitRetVal = 1   -- Valid
  RETURN @bitRetVal
END 
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[cateName] [nvarchar](50) NULL,
	[cateDescription] [nvarchar](50) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[view_list_Category]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[view_list_Category]
as
select *
from Categories
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[brandName] [nvarchar](50) NULL,
	[brandDescription] [text] NULL,
	[brandHomePage] [nvarchar](250) NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[view_list_Brand]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[view_list_Brand]
as
select *
from Brands
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[idUser] [int] IDENTITY(1,1) NOT NULL,
	[accountName] [nvarchar](50) NOT NULL,
	[passWord] [nvarchar](50) NOT NULL,
	[idCusAuthe] [int] NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Sex] [bit] NULL,
	[Address] [nvarchar](250) NULL,
	[phoneNumber] [nvarchar](50) NULL,
	[Email] [nvarchar](250) NOT NULL,
	[dateRegistation] [date] NULL,
	[dateActivated] [date] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Customer__97367C9ECE8E952B] UNIQUE NONCLUSTERED 
(
	[passWord] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Customer__A76EB6A17CF04B55] UNIQUE NONCLUSTERED 
(
	[accountName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[F_getCustomerByID]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[F_getCustomerByID](@id int)
RETURNS TABLE
AS
	RETURN SELECT * FROM Customers WHERE idUser=@id
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[id_user] [int] NOT NULL,
	[id_product] [int] NOT NULL,
	[count] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_user] ASC,
	[id_product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cusAuthe]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cusAuthe](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nameAuthe] [varchar](50) NULL,
 CONSTRAINT [PK_cusAuthe] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cusAuthe_Roles]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cusAuthe_Roles](
	[idCusAuthe] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
	[Note] [nvarchar](250) NULL,
 CONSTRAINT [PK_cusAuthe_Roles] PRIMARY KEY CLUSTERED 
(
	[idCusAuthe] ASC,
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[orderID] [int] NOT NULL,
	[productID] [int] NOT NULL,
	[unitPrice] [decimal](18, 0) NULL,
	[Quantity] [nchar](10) NULL,
	[intoMoney] [decimal](18, 0) NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[orderID] ASC,
	[productID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[createDate] [date] NULL,
	[requireDate] [date] NULL,
	[addressTo] [nvarchar](250) NULL,
	[Active] [nvarchar](250) NULL,
	[CustomerID] [int] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[productName] [nvarchar](250) NOT NULL,
	[productDescription] [text] NULL,
	[Price] [decimal](18, 0) NULL,
	[promotionPrice] [decimal](18, 0) NULL,
	[productPicture] [nvarchar](150) NULL,
	[categoryID] [int] NULL,
	[createDate] [date] NULL,
	[viewCount] [int] NULL,
	[productStatus] [bit] NULL,
	[BrandID] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
	[Detail] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD FOREIGN KEY([id_product])
REFERENCES [dbo].[Products] ([ID])
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD FOREIGN KEY([id_user])
REFERENCES [dbo].[Customers] ([idUser])
GO
ALTER TABLE [dbo].[cusAuthe_Roles]  WITH CHECK ADD  CONSTRAINT [FK_cusAuthe_Roles_cusAuthe] FOREIGN KEY([idCusAuthe])
REFERENCES [dbo].[cusAuthe] ([id])
GO
ALTER TABLE [dbo].[cusAuthe_Roles] CHECK CONSTRAINT [FK_cusAuthe_Roles_cusAuthe]
GO
ALTER TABLE [dbo].[cusAuthe_Roles]  WITH CHECK ADD  CONSTRAINT [FK_cusAuthe_Roles_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[cusAuthe_Roles] CHECK CONSTRAINT [FK_cusAuthe_Roles_Role]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_cusAuthe] FOREIGN KEY([idCusAuthe])
REFERENCES [dbo].[cusAuthe] ([id])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_cusAuthe]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([orderID])
REFERENCES [dbo].[Orders] ([ID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY([productID])
REFERENCES [dbo].[Products] ([ID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_User] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([idUser])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_User]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Brands] FOREIGN KEY([BrandID])
REFERENCES [dbo].[Brands] ([ID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Brands]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([categoryID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
/****** Object:  StoredProcedure [dbo].[Add_new_Brand]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Add_new_Brand] @brandName nvarchar(250), @brandDescription nvarchar(250), @brandHomePage nvarchar(250)
as
	if exists( select Top(10) brandName
				from Brands
				where brandName=@brandName)
	begin
		print 'Ten danh muc da co.'
	end
	else
	begin
		insert into Brands(brandName,brandDescription,brandHomePage) values(@brandName,@brandDescription,@brandHomePage)
	end
GO
/****** Object:  StoredProcedure [dbo].[Add_new_Cate]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Add_new_Cate] @cateName nvarchar(250), @cateDescription nvarchar(250)
as
	if exists( select Top(10) cateName
				from Categories
				where cateName=@cateName)
	begin
		print 'Ten danh muc da co.'
	end
	else
	begin
		insert into Categories(cateName,cateDescription) values(@cateName,@cateDescription)
	end
GO
/****** Object:  StoredProcedure [dbo].[C_Customers]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[C_Customers]
@accountName nvarchar(50),
@passWord nvarchar(50),
@idCusAuthe int,
@FirstName nvarchar(50),
@LastName nvarchar(50),
@Sex bit,
@Address nvarchar(250),
@phoneNumber nvarchar(250),
@Email nvarchar(250),
@dateRegistation date,
@dateActivated date
AS
BEGIN TRAN
	IF NOT EXISTS(SELECT * FROM Customers WHERE accountName = @accountName)		
		BEGIN 
			INSERT INTO Customers(accountName, passWord,idCusAuthe, FirstName, LastName, Sex, Address, phoneNumber, Email, dateRegistation, dateActivated)
			VALUES(@accountName, @passWord, @idCusAuthe, @FirstName, @LastName, @Sex, @Address, @phoneNumber, @Email, @dateRegistation, @dateActivated);
			COMMIT;
		END
	ELSE
		BEGIN
			ROLLBACK;
		END
GO
/****** Object:  StoredProcedure [dbo].[del_Brands]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[del_Brands] @id int
as
	if exists(select brandName
			  from Brands
			  where ID=@id)
	begin
		delete from Brands where ID=@id
    end
		else
	begin
			 print 'Danh muc khong ton tai';
	end
GO
/****** Object:  StoredProcedure [dbo].[del_cate]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[del_cate] @id int
as
	if exists(select cateName
			  from Categories
			  where ID=@id)
	begin
		delete from Categories where ID=@id
    end
		else
	begin
			print 'Danh muc khong ton tai'
	end
GO
/****** Object:  StoredProcedure [dbo].[Delete_Customer]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Delete_Customer] @idUser int
as
begin
	DELETE FROM Customers WHERE idUser=@idUser
end
GO
/****** Object:  StoredProcedure [dbo].[edit_Brands]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[edit_Brands] @id int, @brandName nvarchar(50), @brandDescription nvarchar(250),@brandHomePage nvarchar(250) 
as
begin 
	update Brands
	set brandName=@brandName, brandDescription=@brandDescription,brandHomePage=@brandHomePage
	where ID=@id
end
GO
/****** Object:  StoredProcedure [dbo].[edit_cate]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[edit_cate] @id int, @nameCate nvarchar(50), @desCate nvarchar(250)
as
begin 
	update Categories
	set cateName= @nameCate, cateDescription=@desCate
	where ID=@id
end
GO
/****** Object:  StoredProcedure [dbo].[get_a_Brands]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[get_a_Brands] @id int
as
begin
	select brandName, brandDescription
	from Brands
	where ID=@id
end
GO
/****** Object:  StoredProcedure [dbo].[get_a_cate]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[get_a_cate] @id int
as
begin
	select cateName, cateDescription
	from Categories
	where ID=@id
end
GO
/****** Object:  StoredProcedure [dbo].[search_Brand]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[search_Brand] @brandName nvarchar(50)=null
AS
SELECT ID, brandName, brandDescription,brandHomePage
FROM Brands
WHERE (@brandName IS NULL OR brandName LIKE '%' + @brandName + '%')
     
GO
/****** Object:  StoredProcedure [dbo].[search_Cate]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[search_Cate] @namecate nvarchar(50)=null
AS
SELECT ID, cateName, cateDescription
FROM Categories
WHERE (@namecate IS NULL OR cateName LIKE '%' + @namecate + '%')
     
GO
/****** Object:  StoredProcedure [dbo].[Update_Customers]    Script Date: 12/11/2020 5:51:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Update_Customers]
@idUser int,
@accountName nvarchar(50),
@passWord nvarchar(50),
@idCusAuthe int,
@FirstName nvarchar(50),
@LastName nvarchar(50),
@Sex bit,
@Address nvarchar(250),
@phoneNumber nvarchar(250),
@Email nvarchar(250),
@dateRegistation date,
@dateActivated date
AS
BEGIN
	UPDATE Customers
	SET accountName=@accountName, passWord=@passWord, idCusAuthe=@idCusAuthe, FirstName=@FirstName, LastName=@LastName, Sex=@Sex, Address=@Address, phoneNumber=@phoneNumber, Email=@Email, dateRegistation=@dateRegistation, dateActivated=@dateRegistation
	WHERE idUser=@idUser
END
GO
USE [master]
GO
ALTER DATABASE [DBLaptop] SET  READ_WRITE 
GO
