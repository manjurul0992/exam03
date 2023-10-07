Create database exam03
go
 use exam03
 go
 create table Category(
 CId int primary key identity(1,1),
 CName NVARCHAR(100) not null
 )
 Go
 insert into Category Values ('Ground')
 insert into Category Values ('Field')
 insert into Category Values ('Board')
 create table Game(
 Id int primary key identity(1,1),
 GameName NVARCHAR(100) not null,
 Prize money not null,
 PlayDate Datetime not null,
 Result bit not null,
 PicturePath Nvarchar(max) not null,
 CId int not null,
 foreign key (CId) references Category (CId)
 )
 select * from Category
  select * from Game