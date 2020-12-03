CREATE PROC [dbo].[C_Customers]
@accountName nvarchar(50),
@passWord nvarchar(50),
@FirstName nvarchar(50),
@LastName nvarchar(50),
@Sex bit,
@Address nvarchar(250),
@phoneNumber nvarchar(250),
@Email nvarchar(250),
@dateRegistation nchar(10),
@dateActivated date,
@Decentralization bit,
@Active bit

AS
BEGIN TRAN
	IF NOT EXISTS(SELECT * FROM Customers WHERE accountName = @accountName)		
		BEGIN 
			INSERT INTO Customers(accountName, passWord, FirstName, LastName, Sex, Address, phoneNumber, Email, dateRegistation, dateActivated, Decentralization, Active)
			VALUES(@accountName, @passWord, @FirstName, @LastName, @Sex, @Address, @phoneNumber, @Email, @dateRegistation, @dateActivated, @Decentralization, @Active);
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
	RETURN SELECT * FROM Customers WHERE id=@id

select * from F_getCustomerByID(3)

CREATE PROC [dbo].[Update_Customers]
@id int,
@accountName nvarchar(50),
@passWord nvarchar(50),
@FirstName nvarchar(50),
@LastName nvarchar(50),
@Sex bit,
@Address nvarchar(250),
@phoneNumber nvarchar(250),
@Email nvarchar(250),
@dateRegistation nchar(10),
@dateActivated date,
@Decentralization bit,
@Active bit
AS
BEGIN
	UPDATE Customers
	SET accountName=@accountName, passWord=@passWord, FirstName=@FirstName, LastName=@LastName, Sex=@Sex, Address=@Address, phoneNumber=@phoneNumber, Email=@Email, dateRegistation=@dateRegistation, dateActivated=@dateRegistation, Decentralization=@Decentralization, Active=@Active
	WHERE id=@id
END
GO

create procedure Delete_Customer @id int
as
begin
	DELETE FROM Customers WHERE id=@id
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

select dbo.vaValidEmail('letranduchuy@gmail.com')