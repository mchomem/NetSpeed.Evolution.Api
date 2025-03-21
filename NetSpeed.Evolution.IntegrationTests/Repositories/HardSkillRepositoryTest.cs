namespace NetSpeed.Evolution.IntegrationTests.Repositories;

public class HardSkillRepositoryTest : IDisposable
{
    private readonly AppDbContext _dbContext;
    private readonly RepositoryBase<HardSkill> _repositoryBase;
    private readonly HardSkillRepository _hardSkillRepository;
    private bool _disposed = false;

    public HardSkillRepositoryTest()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}")
            .Options;

        _dbContext = new AppDbContext(options);
        _repositoryBase = new RepositoryBase<HardSkill>(_dbContext);
        _hardSkillRepository = new HardSkillRepository(_repositoryBase);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    [Fact]
    public async Task CreateAsync_SingleEntityHardSkill_ShouldReturnHardSkill()
    {
        // Arrange
        var hardSkill = new HardSkill("C#");

        // Act
        var result = await _hardSkillRepository.CreateAsync(hardSkill);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().BeGreaterThan(0);

        var dbHardSkill = await _repositoryBase.GetAsync(result.Id);
        dbHardSkill.Should().NotBeNull();
        dbHardSkill.Name.Should().Be("C#");
    }

    [Fact]
    public async Task GetAsync_SingleEntityHardSkill_ShouldReturnHardSkill()
    {
        // Arrange
        var hardSkill = new HardSkill("asp.net mvc");
        await _hardSkillRepository.CreateAsync(hardSkill);

        // Act
        var result = await _hardSkillRepository.GetAsync(hardSkill.Id);

        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be("asp.net mvc");
    }

    [Fact]
    public async Task GetAllAsync_EnumerableEntityHardSkill_ShouldReturnAllHardSkills()
    {        
        // Arrange
        await _hardSkillRepository.CreateAsync(new HardSkill("C++"));
        await _hardSkillRepository.CreateAsync(new HardSkill("Typescript"));

        // Act
        var result  = await _hardSkillRepository.GetAllAsync(_ => true);

        // Assert
        result.Should().HaveCount(2);
    }

    [Fact]
    public async Task UpdateAsync_SingleEntityHardSkill_ShouldReturnModifyHardSkill()
    {
        // Arrange
        var hardSkill = new HardSkill("C#");
        await _hardSkillRepository.CreateAsync(hardSkill);

        // Act
        hardSkill.Update("C# .net");
        var result = await _hardSkillRepository.UpdateAsync(hardSkill);
        
        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be("C# .net");
    }

    [Fact]
    public async Task DeleteAsync_SingleEntityHardSkill_ShouldReturnHardSkillLogicalDeleted()
    {
        // Arrange
        var hardSkill = new HardSkill("C#");
        await _hardSkillRepository.CreateAsync(hardSkill);

        // Act
        hardSkill.Delete();
        await _hardSkillRepository.UpdateAsync(hardSkill);

        // Assert
        var hardSkillsLogicallyDeleted = await _hardSkillRepository.GetAsync(hardSkill.Id);
        hardSkillsLogicallyDeleted.IsDeleted.Should().BeTrue();
    }

    [Fact]
    public async Task DeleteAsync_SingleEntityHardSkill_ShouldReturnDeletedHardSkill()
    {
        // Arrange
        var hardSkill = new HardSkill("C#");
        await _hardSkillRepository.CreateAsync(hardSkill);

        // Act
        await _hardSkillRepository.DeleteAsync(hardSkill);

        // Assert
        var deletedHardSkill = await _hardSkillRepository.GetAsync(hardSkill.Id);
        deletedHardSkill.Should().BeNull();
    }

    [Fact]
    public async Task CheckIfExists_ShouldReturnTrue_WhenHardSkillExists()
    {
        // Arrange
        var hardSkill = new HardSkill("C#");
        await _hardSkillRepository.CreateAsync(hardSkill);

        // Act
        var exists = await _hardSkillRepository.CheckIfExists(d => d.Name == "C#");

        // Assert
        exists.Should().BeTrue();
    }

    [Fact]
    public async Task CheckIfExists_ShouldReturnFalse_WhenHardSkillDoesNotExist()
    {
        // Act
        var exists = await _hardSkillRepository.CheckIfExists(d => d.Name == "Inexistente");

        // Assert
        exists.Should().BeFalse();
    }
}
