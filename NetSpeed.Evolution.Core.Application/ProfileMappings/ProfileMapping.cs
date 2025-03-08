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
    }
}
