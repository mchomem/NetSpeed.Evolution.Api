namespace NetSpeed.Evolution.Core.Application.ProfileMappings;

public class ProfileMapping : Profile
{
    public ProfileMapping()
    {
        #region JobTitle

        CreateMap<JobTitle, JobTitleDto>().ReverseMap();
        CreateMap<JobTitle, JobTitleInsertDto>().ReverseMap();
        CreateMap<JobTitle, JobTitleUpdateDto>().ReverseMap();

        #endregion

        #region Department

        CreateMap<Department, DepartmentDto>().ReverseMap();
        CreateMap<Department, DepartmentInsertDto>().ReverseMap();
        CreateMap<Department, DepartmentUpdateDto>().ReverseMap();

        #endregion

        #region HardSkill

        CreateMap<HardSkill, HardSkillDto>().ReverseMap();
        CreateMap<HardSkill, HardSkillInsertDto>().ReverseMap();
        CreateMap<HardSkill, HardSkillUpdateDto>().ReverseMap();

        #endregion

        #region Employee

        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<Employee, EmployeeInsertDto>().ReverseMap();
        CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();

        #endregion

        #region EmployeeHardSkill

        CreateMap<EmployeeHardSkill, EmployeeHardSkillDto>().ReverseMap();
        CreateMap<EmployeeHardSkill, EmployeeHardSkillInsertDto>().ReverseMap();
        CreateMap<EmployeeHardSkill, EmployeeHardSkillUpdateDto>().ReverseMap();

        #endregion

        #region Swot

        CreateMap<Swot, SwotDto>().ReverseMap();
        CreateMap<Swot, SwotInsertDto>().ReverseMap();
        CreateMap<Swot, SwotUpdateDto>().ReverseMap();

        #endregion

        #region Strength

        CreateMap<Strength, StrengthDto>().ReverseMap();
        CreateMap<Strength, StrengthInsertDto>().ReverseMap();
        CreateMap<Strength, StrengthUpdateDto>().ReverseMap();

        #endregion

        #region Opportunity

        CreateMap<Opportunity, OpportunityDto>().ReverseMap();
        CreateMap<Opportunity, OpportunityInsertDto>().ReverseMap();
        CreateMap<Opportunity, OpportunityUpdateDto>().ReverseMap();

        #endregion

        #region Weakness

        CreateMap<Weakness, WeaknessDto>().ReverseMap();
        CreateMap<Weakness, WeaknessInsertDto>().ReverseMap();
        CreateMap<Weakness, WeaknessUpdateDto>().ReverseMap();

        #endregion

        #region Threat

        CreateMap<Threat, ThreatDto>().ReverseMap();
        CreateMap<Threat, ThreatInsertDto>().ReverseMap();
        CreateMap<Threat, ThreatUpdateDto>().ReverseMap();

        #endregion

        #region Cycle

        CreateMap<Cycle, CycleDto>().ReverseMap();
        CreateMap<Cycle, CycleInsertDto>().ReverseMap();
        CreateMap<Cycle, CycleUpdateDto>().ReverseMap();

        #endregion

        #region User

        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, UserInsertDto>().ReverseMap();

        #endregion

        #region ActionPlain5W2H

        CreateMap<ActionPlain5W2H, ActionPlain5W2HDto>().ReverseMap();
        CreateMap<ActionPlain5W2H, ActionPlain5W2HInsertDto>().ReverseMap();
        CreateMap<ActionPlain5W2H, DepartmentUpdateDto>().ReverseMap();

        #endregion

        #region EmployeeTaskDto

        CreateMap<EmployeeTask, EmployeeTaskDto>().ReverseMap();

        #endregion
    }
}
