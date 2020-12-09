
-- tim kiem cate
create PROCEDURE search_Cate @namecate nvarchar(50)=null
AS
SELECT ID, cateName, cateDescription
FROM Categories
WHERE (@namecate IS NULL OR cateName LIKE '%' + @namecate + '%')
     

-- tao view cate
create view view_list_Category
as
select *
from Categories

-- them 1 cate moi
create procedure Add_new_Cate @cateName nvarchar(250), @cateDescription nvarchar(250), @catePicture nvarchar(250)
as
	if exists( select Top(10) cateName
				from Categories
				where cateName=@cateName)
	begin
		print 'Ten danh muc da co.'
	end
	else
	begin
		insert into Categories(cateName,cateDescription,catePicture) values(@cateName,@cateDescription,@catePicture)
	end
-- xoa cate bang ten
create procedure del_cate @cateName nvarchar(250)
as
	if exists(select cateName
			  from Categories
			  where cateName=@cateName)
	begin
		delete from Categories where cateName=@cateName
    end
		else
	begin
			'Danh muc khong ton tai'
	end


--chinh sua cate bang name
create proc edit_cate @id int, @nameCate nvarchar(50), @desCate nvarchar(250)
as
begin 
	update Categories
	set cateName= @nameCate, cateDescription=@desCate
	where ID=@id
end



-- lay 1 cate bang id
create proc get_a_cate @id int
as
begin
	select cateName, cateDescription
	from Categories
	where ID=@id
end
