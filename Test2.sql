--1
select city,count(au_id) count_of_authors from authors
group by city 

--2
select au_lname,au_fname from authors
where city!=(select city from publishers where pub_name = 'New Moon Books')

--3
create proc proc_ChangePriceUsingAuthorName(@au_lastname varchar(20), @au_firstname varchar(20), @new_price float)
as
begin
   Update titles set price=@new_price
   where title_id=(
   select title_id from titleauthor where au_id=(
   select au_id from authors 
   where au_lname=@au_lastname and au_fname=@au_firstname))
end
exec proc_ChangePriceUsingAuthorName 'White','Johnson',22.34

--4
create function fn_CalTax(@quantity int)
returns float
as
begin
    declare
	@Tax float
	if(@quantity<10)
	   set @Tax=2
	else if(@quantity>10 and @quantity<20)
	   set @Tax=5
	else if(@quantity>20 and @quantity<50)
	   set @Tax=6
	else
	   set @Tax=7.5
	return @Tax
end

select qty,dbo.fn_CalTax(qty) 'Tax %' from Sales 