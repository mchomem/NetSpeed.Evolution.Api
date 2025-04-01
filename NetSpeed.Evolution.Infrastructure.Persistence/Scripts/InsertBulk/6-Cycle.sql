use NetSpeedEvolution
go

delete from Cycle
go

dbcc checkident('Cycle', ressed, 0)
go

insert into Cycle([Year], [Active], CreatedAt) values(year(getdate()), 1, getdate())
go
