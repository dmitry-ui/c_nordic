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

--создать процедуру Add
go
create procedure AddRecord(@Date datetime, @Message nvarchar(256), @ContactId nvarchar(64))
as
BEGIN
	set nocount on
	declare @status int
	select @status = id from Statuses where Name = 'Awating'

	insert into Reminders (id, Date, Message, ContactId, Status)
	values (newid(), @Date, @Message, @ContactId, @status)
END;
go
--проверка
--exec AddRecord '2019-11-29 18:37:00.667', 'Film', '123456'
--exec AddRecord '2019-11-30 18:37:00.667', 'Read', '123456'
--select * from Reminders

--создать процедуру Update
go
create procedure UpdateStatus (@id uniqueidentifier, @status nvarchar(64))
as
begin
	set nocount on
	declare @tempStatusId int
	select @tempStatusId = Id from Statuses where name = @status

	update  Reminders
	set Status = @tempStatusId
	where id = @id
end
go
--проверка
--select * from Reminders
--exec UpdateStatus 'A0CF4AB3-F14C-4F3D-881B-91AF695D1A13', 'Failed'
--select * from Reminders

--создать функцию Get(Guid Id);
go 
create function  GetReminderItemById (@id uniqueidentifier)
returns @ReminderItems table
(
	Id uniqueidentifier, 
	Date datetime not null,					
	Message nvarchar(256) not null,			
	ContactId nvarchar(64) not null,			
	Status int not null,						
	TimeToAllarm int,				
	IsReadyToSend bit	
)
as
begin
	insert @ReminderItems
	select 	Id, Date, Message, ContactId, Status, TimeToAllarm, IsReadyToSend 
	from Reminders
	where Id = @id
return
end
go
--проверка
--select * from Reminders
--select * from  GetReminderItemById('69671DA0-D818-4E82-8AE2-D64156B5AE1A')


--создать процедуру Get(ReminderItemStatus status);
go 
create function  GetReminderItemsByStatus (@status nvarchar(64))
returns table
as
return
(		
	select 	Id, Date, Message, ContactId, Status, TimeToAllarm, IsReadyToSend 
	from Reminders
	where Status = (
						select Id 
						from Statuses 
						where name = @status
					)
)

go
----проверка
select * from Reminders
select * from Statuses
select * from  GetReminderItemsByStatus(N'Failed')


