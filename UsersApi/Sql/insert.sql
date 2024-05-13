create database LibraryDB;

use LibraryDB;

create table [Users] 
(
	[Id] int primary key identity,
	[Username] nvarchar(100),
	[BirthDate] datetime2,
)

insert into Users(Username, BirthDate)
values('Tima', '28.04.2007')