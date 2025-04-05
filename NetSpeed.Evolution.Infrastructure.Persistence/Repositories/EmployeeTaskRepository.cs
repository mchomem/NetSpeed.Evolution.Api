namespace NetSpeed.Evolution.Infrastructure.Persistence.Repositories;

public class EmployeeTaskRepository : IEmployeeTaskRepository
{
    private readonly IRepositoryBase<EmployeeTask> _repositoryBase;
     
    public EmployeeTaskRepository(IRepositoryBase<EmployeeTask> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task<IEnumerable<EmployeeTask>> GetAllTasksEmployeeAsync(params object[] parameters)
    {
        var query = new StringBuilder();
        query.AppendLine("select");
        query.AppendLine(" s.EmployeeId [EmployeeId]");
        query.AppendLine("    , c.Id [CycleId]");
        query.AppendLine("    , case");
        query.AppendLine("         when s.[Status] = 'Available' then 'Seu formulário SWOT ' +  cast(c.Year as varchar) + ' está dispónivel'");
        query.AppendLine("         when s.[Status] = 'Draf' then 'Forumário SWOT em rascunho'");
        query.AppendLine("         when s.[Status] = 'ReturnedReview' then 'Seu gestor devolveu o seu SWOT com considerações'");
        query.AppendLine("    end [TaskDescrption]");
        query.AppendLine(",   'SWOT' [EmployeeTaskType]");
        query.AppendLine("    , EmployeeId [EmployeeId]");
        query.AppendLine(" from");
        query.AppendLine("    Swot s");
        query.AppendLine("    join Cycle c on (c.id = s.CycleId and c.Active = 1)");
        query.AppendLine(" where");
        query.AppendLine("    s.EmployeeId = @p0");
        query.AppendLine("    and s.CycleId = @p1");
        query.AppendLine("    and s.[Status] in('Available', 'Draft')");


        var employeeTasks = await _repositoryBase.ExecuteRawSqlAsync(
            query.ToString(),
            render => new EmployeeTask(render.GetInt64(0), render.GetInt64(1), render.GetString(2), render.GetString(3)),
            parameters);

        return employeeTasks;
    }

    public async Task<IEnumerable<EmployeeTask>> GetAllTasksManagerEmployeeAsync(params object[] parameters)
    {
        var query = new StringBuilder();
        query.AppendLine("select");
        query.AppendLine("    Id [EmployeeId]");
        query.AppendLine(",   (select top 1 id from Cycle where Active = 1) [CycleId]");
        query.AppendLine(",   'Disponibiizar o SWOT ' + cast( (select top 1 Year from Cycle where Active = 1) as varchar) + ' para o colaborador(a) ' + e.Name + ' - Matrícula: ' + e.RegistrationNumber [TaskDescrption]");
        query.AppendLine(",   'SWOT' [EmployeeTaskType]");
        query.AppendLine(" from");
        query.AppendLine("     Employee e");
        query.AppendLine(" where");
        query.AppendLine("     ManagerId = @p0");
        query.AppendLine("     and Id not in(select EmployeeId from Swot where CycleId = @p1)");

        var employeeTasks = await _repositoryBase.ExecuteRawSqlAsync(
            query.ToString(),
            render => new EmployeeTask(render.GetInt64(0), render.GetInt64(1), render.GetString(2), render.GetString(3)),
            parameters);

        return employeeTasks;
    }
}
