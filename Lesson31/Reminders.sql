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
	Date datetime not null,					-- ���� �������� ���������
	Message nvarchar(256) not null,			--����� ���������
	ContactId nvarchar(64) not null,			--���� ����������
	Status int not null,						--������ ���������
	TimeToAllarm int,				--����� �� ����������� ����� �������� ���������
	IsReadyToSend bit,				--����, ���� ���������� ���������
	Constraint PK_Reminders primary key (Id),
	Constraint FK_Status foreign key (Status) references  Statuses (Id)
)

--select * from Statuses
--select * from Reminders
