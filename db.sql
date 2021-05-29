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

create table Reviews(
id int Identity(1,1) primary key,
[user_id] int references Users(id) on delete cascade,
[text] varchar(300)
)

select email, [text] from Reviews join Users on Reviews.user_id = Users.id
SELECT * FROM Tables WHERE NOT EXISTS (SELECT * FROM Bron WHERE Bron.table_id = Tables.id and Bron.event_id != 2);