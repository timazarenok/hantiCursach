create database HutniBrovar;

use HutniBrovar;

create table Users(
id int Identity(1,1) primary key,
[email] varchar(30)
)

create table [Tables](
id int Identity(1,1) primary key,
number int,
amount int
)

create table [Events](
id int Identity(1,1) primary key,
[name] varchar(30),
[date] date
)

create table Bron (
id int Identity(1,1) primary key,
table_id int references [Tables](id) on delete cascade,
[user_id] int references Users(id) on delete cascade,
[event_id] int references [Events](id) on delete cascade,
telephone varchar(15),
[time] varchar(5)
)

create table Products(
id int Identity(1,1) primary key,
[name] varchar(50),
price decimal(10,2)
)

create table Bron_Products (
id int Identity(1,1) primary key,
bron_id int references Bron(id) on delete cascade,
product_id int references Products(id) on delete cascade,
)

create table Reviews(
id int Identity(1,1) primary key,
[user_id] int references Users(id) on delete cascade,
[text] varchar(300)
)

