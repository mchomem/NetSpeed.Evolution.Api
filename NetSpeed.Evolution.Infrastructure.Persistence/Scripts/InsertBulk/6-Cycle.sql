use NetSpeedEvolution
go

delete from Cycle
go

dbcc checkident('Cycle', ressed, 0)
go

insert into Cycle([Year], CreatedAt) values(year(getdate()), getdate())
go
