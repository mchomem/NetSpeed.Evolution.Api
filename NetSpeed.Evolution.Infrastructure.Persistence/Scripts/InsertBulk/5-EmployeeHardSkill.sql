use [NetSpeedEvolution]
go

delete from EmployeeHardSkills
go

declare @tabEmployess table(id int identity(1, 1), [employeeId] bigint)
insert into @tabEmployess
select id from Employee	

declare @tabHardSkills table(id int identity(1, 1), [hardSkillId] bigint)
insert into @tabHardSkills
select id from HardSkill

declare @tabLevels table(id int identity(1, 1), [value] varchar(15))
insert into @tabLevels ([value])
values
('Beginner')
, ('Intermediate')
, ('Advanced')
, ('Expert')

while( (select count(*) from @tabEmployess) > 0)
begin
	declare @id bigint = 0
	declare @employeeid bigint = 0
	
	select top 1
		@id = id
		, @employeeid = employeeId
	from
		@tabEmployess

	declare @maxRecords int = (floor(rand() * 10) + 1)

	while(@maxRecords > 0)
	begin
		
		set @maxRecords = @maxRecords - 1

		declare @hardSkillId bigint = (select id from HardSkill where id = floor(rand() * (select count(*) from HardSkill) ) + 1)
		declare @level varchar(15) = (select [value] from @tabLevels where id = floor(rand() * (select count(*) from @tabLevels) ) + 1)

		if exists(select * from EmployeeHardSkills where EmployeeId = @employeeid and HardSkillId = @hardSkillId)
			continue

		insert into [dbo].[EmployeeHardSkills]
		(
			[EmployeeId]
			, [HardSkillId]
			, [Level]
		)
		values
		(
			@employeeid         --<EmployeeId, bigint,>
			, @hardSkillId      --,<HardSkillId, bigint,>
			, @level            --,<Level, varchar(15),>
		)
	end

	delete from @tabEmployess where id = @id
end
go

select * from EmployeeHardSkills
go