use DBLaptop
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

CREATE FUNCTION F_getCustomerByID(@id int)
RETURNS TABLE
AS
	RETURN SELECT * FROM Customers WHERE idUser=@id


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

create procedure Delete_Customer @idUser int
as
begin
	DELETE FROM Customers WHERE idUser=@idUser
end

--Xác thực email
CREATE FUNCTION vaValidEmail(@EMAIL varchar(100))
RETURNS bit as
BEGIN     
  DECLARE @bitRetVal as Bit
  IF (@EMAIL <> '' AND @EMAIL NOT LIKE '_%@__%.__%')
     SET @bitRetVal = 0  -- Invalid
  ELSE 
    SET @bitRetVal = 1   -- Valid
  RETURN @bitRetVal
END 
--trigger them vao gio hang
create trigger Trg_Cart on Cart after insert as
BEGIN TRANSACTION;
	UPDATE Products
	SET viewCount = viewCount - (
		SELECT count
		FROM inserted
		WHERE id_product = Products.ID
	)
	FROM Products
	JOIN inserted ON Products.ID = inserted.id_product
COMMIT TRANSACTION;

CREATE trigger Trg_UpdateCart on Cart after update as
BEGIN TRANSACTION;
	UPDATE Products
	SET viewCount = viewCount - (
		SELECT count
		FROM inserted
		WHERE id_product = Products.ID
	) +(
		SELECT count
		FROM deleted
		WHERE id_product = Products.ID
	)
	FROM Products
	JOIN inserted ON Products.ID = inserted.id_product
	Join deleted on Products.ID = deleted.id_product
COMMIT TRANSACTION;

--trigger hủy bỏ sản phẩm trong giỏ hàng
CREATE trigger Trg_DelCart on Cart for delete as
BEGIN TRANSACTION;
	UPDATE Products
	SET viewCount = viewCount + (
		SELECT count
		FROM deleted
		WHERE id_product = Products.ID
	)
	FROM Products
	JOIN deleted ON Products.ID = deleted.id_product
COMMIT TRANSACTION;

--tự động thêm ngày tháng trong bảng Orders
CREATE TRIGGER Trg_InsertOrder on Orders 
after insert,update
as
begin transaction;
	update Orders
	set createDate=GETDATE(), requireDate=DATEADD(DAY,3,GETDATE())
	from Orders inner join inserted
	on Orders.ID=inserted.ID
commit transaction;