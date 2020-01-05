create database A_Reminder

use A_Reminder

create table Statuses
(
	Id int identity(1,1),
	Name nvarchar(64) not null,
	Constraint PK_Statuses primary key (Id)
)

insert into Statuses ( Name)
values ('Awating'), ('Ready'), ('Sent'), ('Failed')
--select * from Statuses

create table Reminders
(
	Id uniqueidentifier, --id
	Date datetime not null,					-- дата отправки сообщения
	Message nvarchar(256) not null,			--текст сообщения
	ContactId nvarchar(64) not null,			--кому отправлять
	Status int not null,						--статус сообщения
	TimeToAllarm int,				--время до наступления срока отправки сообщения
	IsReadyToSend bit,				--флаг, пора отправлять сообщение
	Constraint PK_Reminders primary key (Id),
	Constraint FK_Status foreign key (Status) references  Statuses (Id)
)

--select * from Statuses
--select * from Reminders
