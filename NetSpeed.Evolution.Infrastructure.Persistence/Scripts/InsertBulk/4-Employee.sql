delete from Employee
go

delete from Employee
go

dbcc checkident ('Employee', RESEED, 0);
go

declare @maxRecords int = 50
declare @index int = 0

declare @tempFirstPersonNames table(id int identity(1 ,1), [name] varchar(15))
insert into @tempFirstPersonNames
values
	-- Names with A
	('Ana'), ('Alberto'), ('Amanda'), ('Adriana'), ('Alex'), ('Arthur'), ('Antônio'), ('Alice'), ('André'), ('Aline'),

	-- Names with B
	('Beatriz'), ('Bruno'), ('Benedito'), ('Bernardo'), ('Bianca'), ('Brenda'), ('Bárbara'), ('Bento'), ('Benjamin'), ('Betina'),

	-- Names with C
	('Carlos'), ('Camila'), ('Cláudia'), ('Caio'), ('Cecília'), ('Cristina'), ('Cláudio'), ('Catarina'), ('Cássio'), ('Cristiano'),

	-- Names with D
	('Daniel'), ('Débora'), ('Douglas'), ('Davi'), ('Diana'), ('Diogo'), ('Diego'), ('Denise'), ('Dalila'), ('Domingos'),

	-- Names with E
	('Eduardo'), ('Elaine'), ('Elias'), ('Estela'), ('Eliane'), ('Enzo'), ('Emanuel'), ('Elisa'), ('Érica'), ('Ester'),

	-- Names with F
	('Fernanda'), ('Fábio'), ('Felipe'), ('Francisco'), ('Fabiana'), ('Flávia'), ('Fernando'), ('Francisca'), ('Félix'), ('Flávio'),

	-- Names with G
	('Gabriel'), ('Gustavo'), ('Giovana'), ('Guilherme'), ('Gabriela'), ('Geovana'), ('Giovanni'), ('Gilberto'), ('Graça'), ('Gerson'),

	-- Names with H
	('Henrique'), ('Heloísa'), ('Helena'), ('Humberto'), ('Heitor'), ('Hugo'), ('Hamilton'), ('Hermes'), ('Helder'), ('Haroldo'),

	-- Names with I
	('Isabela'), ('Isaque'), ('Ivan'), ('Ícaro'), ('Isabel'), ('Irina'), ('Ítalo'), ('Irineu'), ('Isadora'), ('Inácio'),

	-- Names with J
	('João'), ('José'), ('Juliana'), ('Joaquim'), ('Júlia'), ('Jessica'), ('Jorge'), ('Josiane'), ('Jonas'), ('Jennifer'),

	-- Names with K
	('Karla'), ('Kauan'), ('Kátia'), ('Kleber'), ('Karin'), ('Kássio'), ('Keila'), ('Kelly'), ('Kevin'), ('Kaio'),

	-- Names with L
	('Lucas'), ('Luana'), ('Larissa'), ('Leonardo'), ('Luan'), ('Lívia'), ('Lorena'), ('Luiz'), ('Letícia'), ('Luísa'),

	-- Names with M
	('Maria'), ('Miguel'), ('Matheus'), ('Marcos'), ('Melissa'), ('Marta'), ('Maurício'), ('Milena'), ('Manoel'), ('Murilo'),

	-- Names with N
	('Nicolas'), ('Natália'), ('Nelson'), ('Nina'), ('Natanael'), ('Neide'), ('Nilton'), ('Naiara'), ('Nádia'), ('Newton'),

	-- Names with O
	('Otávio'), ('Olívia'), ('Oscar'), ('Orlando'), ('Odete'), ('Osvaldo'), ('Osmar'), ('Otília'), ('Olavo'), ('Onofre'),

	-- Names with P
	('Paulo'), ('Patrícia'), ('Pedro'), ('Priscila'), ('Paloma'), ('Pablo'), ('Paula'), ('Pamela'), ('Poliana'), ('Pedroso'),

	-- Names with Q
	('Quênia'), ('Quintino'), ('Quirino'), ('Quirina'), ('Querubim'), ('Quésia'), ('Quim'), ('Queli'), ('Quíntila'), ('Quintiliano'),

	-- Names with R
	('Rafael'), ('Ricardo'), ('Renata'), ('Rogério'), ('Raquel'), ('Roberta'), ('Rodolfo'), ('Rita'), ('Regina'), ('Ronaldo'),

	-- Names with S
	('Samuel'), ('Sandra'), ('Silvana'), ('Simone'), ('Sérgio'), ('Sebastião'), ('Sofia'), ('Salvador'), ('Sueli'), ('Sabrina'),

	-- Names with T
	('Thiago'), ('Tatiane'), ('Tatiana'), ('Tereza'), ('Tales'), ('Tiago'), ('Telma'), ('Tomás'), ('Tânia'), ('Teodoro'),

	-- Names with U
	('Ulisses'), ('Ubirajara'), ('Uriel'), ('Ursula'), ('Ubaldo'), ('Ubiraci'), ('Úrsula'), ('Urano'), ('Ueliton'), ('Umberto'),

	-- Names with V
	('Vinícius'), ('Valéria'), ('Vanessa'), ('Victor'), ('Valmir'), ('Vera'), ('Vitor'), ('Viviane'), ('Vitória'), ('Valentim'),

	-- Names with W
	('Wellington'), ('Wesley'), ('Willian'), ('Walter'), ('Wagner'), ('Wanda'), ('Wanessa'), ('Wallace'), ('Wilma'), ('Wilson'),

	-- Names with X
	('Xavier'), ('Ximenes'), ('Xuxa'), ('Xênia'), ('Xenofonte'), ('Xisto'), ('Xandro'), ('Xelina'), ('Xerxes'), ('Xênior'),

	-- Names with Y
	('Yara'), ('Yuri'), ('Yasmin'), ('Yan'), ('Yohana'), ('Yohan'), ('Yolanda'), ('Yvone'), ('Ygor'), ('Yurianna'),

	-- Names with Z
	('Zé'), ('Zélia'), ('Zenaide'), ('Zara'), ('Zoraide'), ('Zelma'), ('Zilda'), ('Zacarias'), ('Zora'), ('Zélio')

declare @tempSecondPersonNames table(id int identity(1 ,1), [name] varchar(15))
insert into @tempSecondPersonNames([name])
select [name] from @tempFirstPersonNames

declare @tempThirdPersonNames table(id int identity(1 ,1), [name] varchar(15))
insert into @tempThirdPersonNames([name])
select [name] from @tempFirstPersonNames

while(@maxRecords > 0)
begin
set @maxRecords = @maxRecords - 1
set @index = @index + 1

	declare @firstName varchar(15) = (select [name] from @tempFirstPersonNames where id = floor( (rand() * (select count(*) from @tempFirstPersonNames)) + 1))
	declare @lastName varchar(15) = (select [name] from @tempThirdPersonNames where id = floor( (rand() * (select count(*) from @tempThirdPersonNames)) + 1))
	declare @fullEmployeeName varchar(100) =
		@firstName
		+ ' ' + (select [name] from @tempSecondPersonNames where id = floor( (rand() * (select count(*) from @tempSecondPersonNames)) + 1))
		+ ' ' + @lastName

	declare @email varchar(100) = lower(@firstName) + '.' + lower(@lastName) + '@email.com.br' 
	declare @jobTitleId bigint  = (select id from JobTitle where id = floor(rand() * (select count(*) from JobTitle) + 1))
	declare @departmentId bigint = (select id from Department where id = floor(rand() * (select count(*) from Department) + 1))

	declare @registrationNumber varchar(15) = ''
	declare @maxValues int = 15
	while (@maxValues > 0)
	begin
		set @maxValues = @maxValues - 1
		set @registrationNumber = @registrationNumber + cast(  (floor(rand() * 14) + 1) as varchar(15) ) 
	end

	insert into [dbo].[Employee]
    (
		[Name]
		, [Email]
		, [RegistrationNumber]
		, [JobTitleId]
		, [DepartmentId]
		, [IsDeleted]
	)
     values
    (
		@fullEmployeeName     --<Name, varchar(100),>
        , @email              --,<Email, varchar(100),>
        , @registrationNumber --,<RegistrationNumber, varchar(15),>
        , @jobTitleId         --,<JobTitleId, bigint,>
        , @departmentId       --,<DepartmentId, bigint,>
        , 0                   --,<IsDeleted, bit,>
	)
end
go

declare @Manager1 int, @Manager2 int

with RandomManagers as (
    select top 2 Id 
    from Employee 
    order by newid()
)
select @Manager1 = MIN(Id), @Manager2 = max(Id) from RandomManagers;

update Employee
set ManagerId = case 
    when abs(checksum(newid())) % 2 = 0 then @Manager1 
    else @Manager2 
end
where Id NOT IN (@Manager1, @Manager2);


select * from Employee
go
