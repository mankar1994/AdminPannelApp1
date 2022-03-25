use admindb

Create Table Users (Id int primary key identity,
FirstName varchar(max),
LastName varchar(max),
Email varchar(30),
Password varchar(30),
Gender varchar(Max),
Profile_Image varchar(max),
IsActive bit,
IsVerified bit,
CreatedOn datetime,
UpdatedOn datetime)

drop table Users 

select * from Users
--Create Table VerifyAccount (Id int primary key identity,
--Otp varchar(10),
--UserId int foreign key references Users(id),
--SendTime datetime
--)

Select * from VerifyAccounts;

Create Table VerifyAccounts (Id int primary key identity,
Otp varchar(101),
UserId varchar(100),
SendTime datetime
)