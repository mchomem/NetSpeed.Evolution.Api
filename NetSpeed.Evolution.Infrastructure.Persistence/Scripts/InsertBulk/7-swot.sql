use NetSpeedEvolution
go

delete from Strength
go

dbcc checkident('Strength', reseed, 0)
go

delete from Opportunity
go

dbcc checkident('Opportunity', reseed, 0)
go

delete from Weakness
go

dbcc checkident('Weakness', reseed, 0)
go

delete from Threat
go

dbcc checkident('Threat', reseed, 0)
go

delete from Swot
go

dbcc checkident('Swot', reseed, 0)
go


-- Valores SWOT para criar formu�rios aleatoriamente para colaboradores aleat�rios.
declare @tabSthrengs table (id int identity(1, 1), [value] varchar(100))
insert into @tabSthrengs([value])
values
('Alta produtividade e efici�ncia no trabalho')
, ('Forte capacidade de lideran�a e gest�o de equipe')
, ('Boa comunica��o interpessoal')
, ('Facilidade em aprender novas habilidades')
, ('Comprometimento e responsabilidade com as tarefas')
, ('Adaptabilidade a mudan�as e novos desafios')
, ('Trabalho em equipe e colabora��o eficaz')
, ('Alto n�vel de conhecimento t�cnico na �rea')
, ('Proatividade e iniciativa na resolu��o de problemas')
, ('Capacidade de trabalhar sob press�o')
, ('Organiza��o e planejamento eficiente')
, ('Foco em resultados e metas estabelecidas')
, ('Criatividade e inova��o na execu��o das atividades')
, ('Boa gest�o do tempo e cumprimento de prazos')
, ('Habilidade para tomada de decis�es assertivas')
, ('Postura profissional e �tica no ambiente de trabalho')
, ('Capacidade anal�tica e pensamento estrat�gico')
, ('Facilidade de relacionamento com colegas e superiores')
, ('Experi�ncia consolidada na �rea de atua��o')
, ('Habilidade para motivar e engajar a equipe')

declare @tabWeaknesses table (id int identity(1, 1), [value] varchar(100))
insert into @tabWeaknesses([value])
values
('Dificuldade em delegar tarefas e confiar na equipe')
, ('Falta de organiza��o e planejamento')
, ('Dificuldade em lidar com feedback negativo')
, ('Comunica��o pouco clara ou ineficiente')
, ('Resist�ncia a mudan�as e novas metodologias')
, ('Baixo n�vel de conhecimento t�cnico em determinadas �reas')
, ('Falta de iniciativa e proatividade')
, ('Dificuldade em gerenciar o tempo e cumprir prazos')
, ('Excesso de perfeccionismo, impactando a produtividade')
, ('Baixa capacidade de trabalhar sob press�o')
, ('Dificuldade em resolver conflitos interpessoais')
, ('Depend�ncia excessiva de supervis�o')
, ('Falta de flexibilidade e adapta��o a novas demandas')
, ('Medo de assumir riscos e tomar decis�es')
, ('Baixo engajamento e motiva��o no trabalho')
, ('Pouco conhecimento sobre ferramentas tecnol�gicas')
, ('Dificuldade em lidar com multitarefas')
, ('Falta de confian�a nas pr�prias habilidades')
, ('Dificuldade em desenvolver networking profissional')
, ('Tend�ncia a procrastinar atividades importantes')

declare @tabOpportunities table (id int identity(1, 1), [value] varchar(100))
insert into @tabOpportunities([value])
values
('Possibilidade de cursos e treinamentos para desenvolvimento profissional')
, ('Oportunidade de assumir novos desafios e responsabilidades')
, ('Acesso a novas tecnologias e ferramentas de trabalho')
, ('Crescimento do mercado na �rea de atua��o')
, ('Expans�o da empresa, gerando novas oportunidades internas')
, ('Desenvolvimento de novas habilidades atrav�s de projetos inovadores')
, ('Possibilidade de promo��o e crescimento na carreira')
, ('Maior investimento da empresa no bem-estar dos colaboradores')
, ('Constru��o de um networking profissional mais amplo')
, ('Participa��o em eventos e confer�ncias do setor')
, ('Ado��o de novas metodologias de trabalho mais eficientes')
, ('Oportunidade de internacionaliza��o da carreira')
, ('Incentivos para melhoria da qualidade de vida no trabalho')
, ('Maior integra��o entre diferentes �reas da empresa')
, ('Uso da intelig�ncia artificial para otimizar processos')
, ('Expans�o do home office e flexibilidade no trabalho')
, ('Programas de mentoria e coaching interno')
, ('Parcerias estrat�gicas que beneficiam o desenvolvimento profissional')
, ('Possibilidade de especializa��o em novas �reas de atua��o')
, ('Aumento da valoriza��o de profissionais qualificados no mercado')

declare @tabThreats table (id int identity(1, 1), [value] varchar(100))
insert into @tabThreats([value])
values
('Concorr�ncia acirrada no mercado de trabalho')
, ('Avan�o tecnol�gico r�pido, exigindo constante atualiza��o')
, ('Possibilidade de cortes de pessoal devido a crises econ�micas')
, ('Instabilidade pol�tica e econ�mica afetando o setor')
, ('Mudan�as nas regulamenta��es e leis que impactam o trabalho')
, ('Redu��o de investimentos da empresa em treinamentos')
, ('Dificuldade em acompanhar novas exig�ncias do mercado')
, ('Sobrecarga de trabalho e risco de burnout')
, ('Falta de reconhecimento e valoriza��o profissional')
, ('Conflitos internos na empresa afetando a produtividade')
, ('Possibilidade de terceiriza��o reduzindo oportunidades internas')
, ('Automa��o de processos eliminando postos de trabalho')
, ('Dificuldade em equilibrar vida pessoal e profissional')
, ('Cultura organizacional desalinhada com os valores pessoais')
, ('Aumento de competitividade interna entre colegas')
, ('Falta de incentivo para inova��o dentro da empresa')
, ('Poss�vel estagna��o na carreira devido � falta de oportunidades')
, ('Baixa perspectiva de crescimento dentro da empresa')
, ('Depend�ncia de um �nico conjunto de habilidades, limitando a evolu��o')
, ('Impactos de crises sanit�rias e desastres naturais na organiza��o')


declare @maxEmployess int = 15

while (@maxEmployess > 0)
begin
	set @maxEmployess = @maxEmployess - 1

	-- Seleciona aleat�rioamente um colaborador que possua um superior
	declare @employeeId bigint = 0
	declare @managerId bigint = 0

	select
		@employeeId = Id,
		@managerId = ManagerId
	from
		Employee
	where
		id = (floor(rand() * (select count(*) from Employee)) + 1 )
		and ManagerId is not null
	
	declare @cycleId bigint = (select Id from Cycle where [Year] = year(getdate())) -- Obt�m o ciclo atual.

	-- O mesmo colaborador n�o pode ter um novo formul�rio SWOT no mesmo ciclo do ano.
	if ( (select count(*) from Swot where CycleId = @cycleId and EmployeeId = @employeeId) > 0 )
	begin
		set @maxEmployess = @maxEmployess + 1 -- desfaz o decremento para manter a quantidade total processado de registros.
		continue
	end

	declare @fakeUpdateData int = floor(rand() * 10) + 1

	insert into [dbo].[Swot]
    (
		[EmployeeId]
        ,[CreatedById]
        ,[UpdatedById]
        ,[CreatedAt]
		,[UpdatedAt]
        ,[Status]
        ,[CycleId]
	)
	values
	(
		@employeeId                                         --<EmployeeId, bigint,>
		, @managerId                                        --,<CreatedById, bigint,>
		, iif(@fakeUpdateData > 7, @employeeId, null)       --,<UpdatedById, bigint,>
		, getdate()                                         --,<CreatedAt, datetime,>
		, iif(@fakeUpdateData > 7, getdate(), null)         --,<UpdatedAt, datetime,>
		, iif(@fakeUpdateData > 7, 'Draft', 'Available')    --,<Status, varchar(20),>
		, @cycleId                                          --,<CycleId, bigint,>
	)

	declare @swotId bigint = SCOPE_IDENTITY()

	print 'SwotId: ' + cast(@swotId as varchar)

	-- Inser��o aleat�rio de For�a, Oportunidade, Fraqueza e Ame�a.
	declare @maxSthreng int     = floor(rand() * 10) + 1
	declare @maxOpportunity int = floor(rand() * 10) + 1
	declare @maxWeaknesse int   = floor(rand() * 10) + 1
	declare @maxThreat int      = floor(rand() * 10) + 1
	declare @order int = 0

	-- For�a
	while(@maxSthreng > 0)
	begin
		set @maxSthreng = @maxSthreng - 1
		set @order = @order + 1
		declare @textSthreng varchar(100) = (select [value] from @tabSthrengs where id = floor( (rand() * (select count(*) from @tabSthrengs)) + 1 ))

		insert into [dbo].[Strength]
        (
			[SwotId]
           ,[Description]
           ,[Order]
		)
		values
		(
			@swotId           --<SwotId, bigint,>
			, @textSthreng    --,<Description, varchar(100),>
			, @order          --,<Order, int,>
		)
	end

	set @order = 0

	-- Oportunidade
	while(@maxOpportunity > 0)
	begin
		set @maxOpportunity = @maxOpportunity - 1
		set @order = @order + 1
		declare @textOpportunity varchar(100) = (select [value] from @tabOpportunities where id = floor( (rand() * (select count(*) from @tabOpportunities)) + 1 ))

		insert into [dbo].[Opportunity]
        (
			[SwotId]
           ,[Description]
           ,[Order]
		)
		values
		(
			@swotId               --<SwotId, bigint,>
			, @textOpportunity    --,<Description, varchar(100),>
			, @order              --,<Order, int,>
		)
	end

	set @order = 0

	-- Fraqueza
	while(@maxWeaknesse > 0)
	begin
		set @maxWeaknesse = @maxWeaknesse - 1
		set @order = @order + 1
		declare @textWeaknesse varchar(100) = (select [value] from @tabWeaknesses where id = floor( (rand() * (select count(*) from @tabWeaknesses)) + 1 ))

		insert into [dbo].[Weakness]
        (
			[SwotId]
           ,[Description]
           ,[Order]
		)
		values
		(
			@swotId             --<SwotId, bigint,>
			, @textWeaknesse    --,<Description, varchar(100),>
			, @order            --,<Order, int,>
		)
	end

	set @order = 0

	-- Ame�a
	while(@maxThreat > 0)
	begin
		set @maxThreat = @maxThreat - 1
		set @order = @order + 1
		declare @textThreat varchar(100) = (select [value] from @tabThreats where id = floor( (rand() * (select count(*) from @tabThreats)) + 1 ))

		insert into [dbo].[Threat]
        (
			[SwotId]
           ,[Description]
           ,[Order]
		)
		values
		(
			@swotId          --<SwotId, bigint,>
			, @textThreat    --,<Description, varchar(100),>
			, @order         --,<Order, int,>
		)
	end	

	set @order = 0
end


select * from Swot
select * from Strength
select * from Opportunity
select * from Weakness
select * from Threat
