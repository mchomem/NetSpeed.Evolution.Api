use NetSpeedEvolution
go

delete from JobTitle
go

dbcc checkident('JobTitle', reseed, 0)
go

insert into JobTitle([Name])
values
('Gerente de Projetos')
, ('Analista de Sistemas')
, ('Desenvolvedor')
, ('Analista de Testes')
go
