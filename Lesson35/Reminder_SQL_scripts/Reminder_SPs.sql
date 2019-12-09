--USE [Reminder]
DROP PROCEDURE IF EXISTS [dbo].[AddReminderItem]
GO
CREATE PROCEDURE [dbo].[AddReminderItem] (
	@contactId AS VARCHAR(50),
	@targetDate AS DATETIMEOFFSET,
	@message AS NVARCHAR(200),
	@statusId AS TINYINT
	--@reminderId AS UNIQUEIDENTIFIER OUTPUT
)
AS BEGIN
	SET NOCOUNT ON

	DECLARE
		@now AS DATETIMEOFFSET,
		@tempReminderId AS UNIQUEIDENTIFIER
	
	SELECT 
		@now = SYSDATETIMEOFFSET(),
		@tempReminderId = NEWID(); 

	INSERT INTO [dbo].[ReminderItem](
		[Id],
		[ContactId],
		[TargetDate],
		[Message],
		[StatusId],
		[CreatedDate],
		[UpdatedDate])
	VALUES (
		@tempReminderId,
		@contactId,
		@targetDate,
		@message,
		@statusId,
		@now,
		@now)
	
	select @tempReminderId
END
GO
---
DROP PROCEDURE IF EXISTS [dbo].[GetReminderItemById]
GO
create procedure [dbo].[GetReminderItemById](@id as uniqueidentifier)
as 
begin
	set nocount on
	select Id, ContactId, TargetDate, Message, StatusId
	from  dbo.ReminderItem
	where id=@id
end
go

--
DROP PROCEDURE IF EXISTS [dbo].[GetReminderItemByStatus]
GO
create procedure [dbo].[GetReminderItemByStatus](@statusId as tinyint)
as 
begin
	set nocount on
	select Id, ContactId, TargetDate, Message, StatusId
	from  dbo.ReminderItem
	where StatusId = @statusId
end
go

