/*
Предоставить SQL-скрипты, которые
1. Создадут базу данных AirportInfo
2. В ней создадут одну таблицу DepartureBoard (табло вылетов) чтобы в каждом поле хранилась
следующая информация ( имена полей и типы данных подбираем самостоятельно ):
  ● номере рейса
  ● город и страна вылета и прилёта
  ● дата и время вылета и прилёта (везде местное)
  ● время в полёте
  ● авиакомпания
  ● модель самолёта
3. Вставят 2 записи в таблицу
4. Вернут все поля всех строк таблицы
5. Удалят базу данных AirportInfo
*/

create database AirportInfo
use AirportInfo
create table DepartureBoard 
(
	Number int,
	Depart_City nvarchar(max),
	Depart_Country  nvarchar(max),
	Depart_Date datetime,
	Arriv_City nvarchar(max),
	Arriv_Country  nvarchar(max),
	Arriv_Date datetime,
	TimeInFly as datediff(minute, Depart_Date, Arriv_Date)  PERSISTED,
	Company nvarchar(max),
	Model nvarchar(max)
)

--check
declare @Arriv_Date datetime = dateadd(hh, 1, getdate())
declare @Depart_Date datetime = getdate()
declare @time int =  datediff(minute, @Depart_Date, @Arriv_Date)
select @time


INSERT INTO [dbo].[DepartureBoard]
           ([Number]
           ,[Depart_City]
           ,[Depart_Country]
           ,[Depart_Date]
           ,[Arriv_City]
           ,[Arriv_Country]
           ,[Arriv_Date]
           ,[Company]
           ,[Model])
     VALUES
           (333
           ,'Volgograg'
           ,'Russia'
           ,'2019-12-01 17:00:00.000'
           ,'Moscow'
           ,'Russia'
           ,'2019-12-01 19:00:00.000'
		   ,'Pobeda'
           ,'Yak-40'),
		   (777
           ,'Moscow'
           ,'Russia'
           ,'2019-12-02 17:00:00.000'
           ,'berlon'
           ,'Germany'
           ,'2019-12-02 20:00:00.000'
		   ,'Aeroflot'
           ,'Tu-234')

select * from DepartureBoard

drop database AirportInfo