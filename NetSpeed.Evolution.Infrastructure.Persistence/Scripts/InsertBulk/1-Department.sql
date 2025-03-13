use NetSpeedEvolution
go

delete from Department
go

dbcc checkident('Department', reseed, 0)
go

insert into Department([name])
values
 ('Administrativo')
, ('Comercial')
, ('Desenvolvimento')
, ('Financeiro')
, ('Fiscal-Contábil')
, ('Folha de Pagamento')
, ('Infraestrutura')
, ('Portal Educação')
, ('RH')
, ('TI interna')
go
