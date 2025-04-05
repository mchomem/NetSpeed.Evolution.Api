namespace NetSpeed.Evolution.Infrastructure.Persistence.Repositories;

public class EmployeeTaskRepository : IEmployeeTaskRepository
{
    private readonly IRepositoryBase<EmployeeTask> _repositoryBase;
     
    public EmployeeTaskRepository(IRepositoryBase<EmployeeTask> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task<IEnumerable<EmployeeTask>> ExecuteSqlQueryAsync(params object[] parameters)
    {
        StringBuilder sql = new StringBuilder();
        sql.AppendLine("select");
        sql.AppendLine(" Id [EmployeeId]");
        sql.AppendLine(", (select top 1 id from Cycle where Active = 1) [CycleId]");
        sql.AppendLine(", 'Disponibiizar o SWOT ' + cast( (select top 1 Year from Cycle where Active = 1) as varchar) + ' para o colaborador(a) ' + e.Name + ' - Matrícula: ' + e.RegistrationNumber [TaskDescrption]");
        sql.AppendLine(", 'SWOT' [EmployeeTaskType]");
        sql.AppendLine(" from");
        sql.AppendLine(" Employee e");
        sql.AppendLine(" where");
        sql.AppendLine(" ManagerId = @p0");
        sql.AppendLine(" and Id not in(select EmployeeId from Swot where CycleId = @p1)");

        var employeeTasks = await _repositoryBase.ExecuteRawSqlAsync(
            sql.ToString(),
            render => new EmployeeTask(render.GetInt64(0), render.GetInt64(1), render.GetString(2), render.GetString(3)),
            parameters);

        return employeeTasks;
    }
}
