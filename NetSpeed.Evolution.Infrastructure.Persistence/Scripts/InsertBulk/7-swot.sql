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


-- Valores SWOT para criar formuários aleatoriamente para colaboradores aleatórios.
declare @tabSthrengs table (id int identity(1, 1), [value] varchar(100))
insert into @tabSthrengs([value])
values
('Alta produtividade e eficiência no trabalho')
, ('Forte capacidade de liderança e gestão de equipe')
, ('Boa comunicação interpessoal')
, ('Facilidade em aprender novas habilidades')
, ('Comprometimento e responsabilidade com as tarefas')
, ('Adaptabilidade a mudanças e novos desafios')
, ('Trabalho em equipe e colaboração eficaz')
, ('Alto nível de conhecimento técnico na área')
, ('Proatividade e iniciativa na resolução de problemas')
, ('Capacidade de trabalhar sob pressão')
, ('Organização e planejamento eficiente')
, ('Foco em resultados e metas estabelecidas')
, ('Criatividade e inovação na execução das atividades')
, ('Boa gestão do tempo e cumprimento de prazos')
, ('Habilidade para tomada de decisões assertivas')
, ('Postura profissional e ética no ambiente de trabalho')
, ('Capacidade analítica e pensamento estratégico')
, ('Facilidade de relacionamento com colegas e superiores')
, ('Experiência consolidada na área de atuação')
, ('Habilidade para motivar e engajar a equipe')

declare @tabWeaknesses table (id int identity(1, 1), [value] varchar(100))
insert into @tabWeaknesses([value])
values
('Dificuldade em delegar tarefas e confiar na equipe')
, ('Falta de organização e planejamento')
, ('Dificuldade em lidar com feedback negativo')
, ('Comunicação pouco clara ou ineficiente')
, ('Resistência a mudanças e novas metodologias')
, ('Baixo nível de conhecimento técnico em determinadas áreas')
, ('Falta de iniciativa e proatividade')
, ('Dificuldade em gerenciar o tempo e cumprir prazos')
, ('Excesso de perfeccionismo, impactando a produtividade')
, ('Baixa capacidade de trabalhar sob pressão')
, ('Dificuldade em resolver conflitos interpessoais')
, ('Dependência excessiva de supervisão')
, ('Falta de flexibilidade e adaptação a novas demandas')
, ('Medo de assumir riscos e tomar decisões')
, ('Baixo engajamento e motivação no trabalho')
, ('Pouco conhecimento sobre ferramentas tecnológicas')
, ('Dificuldade em lidar com multitarefas')
, ('Falta de confiança nas próprias habilidades')
, ('Dificuldade em desenvolver networking profissional')
, ('Tendência a procrastinar atividades importantes')

declare @tabOpportunities table (id int identity(1, 1), [value] varchar(100))
insert into @tabOpportunities([value])
values
('Possibilidade de cursos e treinamentos para desenvolvimento profissional')
, ('Oportunidade de assumir novos desafios e responsabilidades')
, ('Acesso a novas tecnologias e ferramentas de trabalho')
, ('Crescimento do mercado na área de atuação')
, ('Expansão da empresa, gerando novas oportunidades internas')
, ('Desenvolvimento de novas habilidades através de projetos inovadores')
, ('Possibilidade de promoção e crescimento na carreira')
, ('Maior investimento da empresa no bem-estar dos colaboradores')
, ('Construção de um networking profissional mais amplo')
, ('Participação em eventos e conferências do setor')
, ('Adoção de novas metodologias de trabalho mais eficientes')
, ('Oportunidade de internacionalização da carreira')
, ('Incentivos para melhoria da qualidade de vida no trabalho')
, ('Maior integração entre diferentes áreas da empresa')
, ('Uso da inteligência artificial para otimizar processos')
, ('Expansão do home office e flexibilidade no trabalho')
, ('Programas de mentoria e coaching interno')
, ('Parcerias estratégicas que beneficiam o desenvolvimento profissional')
, ('Possibilidade de especialização em novas áreas de atuação')
, ('Aumento da valorização de profissionais qualificados no mercado')

declare @tabThreats table (id int identity(1, 1), [value] varchar(100))
insert into @tabThreats([value])
values
('Concorrência acirrada no mercado de trabalho')
, ('Avanço tecnológico rápido, exigindo constante atualização')
, ('Possibilidade de cortes de pessoal devido a crises econômicas')
, ('Instabilidade política e econômica afetando o setor')
, ('Mudanças nas regulamentações e leis que impactam o trabalho')
, ('Redução de investimentos da empresa em treinamentos')
, ('Dificuldade em acompanhar novas exigências do mercado')
, ('Sobrecarga de trabalho e risco de burnout')
, ('Falta de reconhecimento e valorização profissional')
, ('Conflitos internos na empresa afetando a produtividade')
, ('Possibilidade de terceirização reduzindo oportunidades internas')
, ('Automação de processos eliminando postos de trabalho')
, ('Dificuldade em equilibrar vida pessoal e profissional')
, ('Cultura organizacional desalinhada com os valores pessoais')
, ('Aumento de competitividade interna entre colegas')
, ('Falta de incentivo para inovação dentro da empresa')
, ('Possível estagnação na carreira devido à falta de oportunidades')
, ('Baixa perspectiva de crescimento dentro da empresa')
, ('Dependência de um único conjunto de habilidades, limitando a evolução')
, ('Impactos de crises sanitárias e desastres naturais na organização')


declare @maxEmployess int = 15

while (@maxEmployess > 0)
begin
	set @maxEmployess = @maxEmployess - 1

	-- Seleciona aleatórioamente um colaborador que possua um superior
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
	
	declare @cycleId bigint = (select Id from Cycle where [Year] = year(getdate())) -- Obtém o ciclo atual.

	-- O mesmo colaborador não pode ter um novo formulário SWOT no mesmo ciclo do ano.
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

	-- Inserção aleatório de Força, Oportunidade, Fraqueza e Ameça.
	declare @maxSthreng int     = floor(rand() * 10) + 1
	declare @maxOpportunity int = floor(rand() * 10) + 1
	declare @maxWeaknesse int   = floor(rand() * 10) + 1
	declare @maxThreat int      = floor(rand() * 10) + 1
	declare @order int = 0

	-- Força
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

	-- Ameça
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
