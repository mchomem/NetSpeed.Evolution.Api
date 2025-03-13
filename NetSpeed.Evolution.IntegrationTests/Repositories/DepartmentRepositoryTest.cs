﻿namespace NetSpeed.Evolution.IntegrationTests.Repositories;

public class DepartmentRepositoryTest : IDisposable
{
    private readonly AppDbContext _dbContext;
    private readonly RepositoryBase<Department> _repositoryBase;
    private readonly DepartmentRepository _departmentRepository;
    private bool _disposed = false;

    public DepartmentRepositoryTest()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        _dbContext = new AppDbContext(options);
        _dbContext.Database.EnsureCreated();

        _repositoryBase = new RepositoryBase<Department>(_dbContext);
        _departmentRepository = new DepartmentRepository(_repositoryBase);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _dbContext.Database.EnsureDeleted();
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
    public async Task CreateAsync_SingleEntityDepartment_ShouldReturnDepartment()
    {
        // Arrange
        var department = new Department("TI");

        // Act
        var result = await _departmentRepository.CreateAsync(department);
        
        // Assert
        result.Should().NotBeNull();
        result.Id.Should().BeGreaterThan(0);

        var dbDepartment = await _repositoryBase.GetAsync(result.Id);
        dbDepartment.Should().NotBeNull();
        dbDepartment.Name.Should().Be("TI");        
    }

    [Fact]
    public async Task GetAsync_SingleEntityDepartment_ShouldReturnDepartment_WhenExists()
    {
        // Arrange
        var department = new Department("RH");
        await _repositoryBase.CreateAsync(department);

        // Act
        var result = await _departmentRepository.GetAsync(department.Id);

        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be("RH");
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllDepartments()
    {
        // Arrange
        await _repositoryBase.CreateAsync(new Department("Financeiro"));
        await _repositoryBase.CreateAsync(new Department("Compras"));

        // Act
        var result = await _departmentRepository.GetAllAsync(_ => true);

        // Assert
        result.Should().HaveCount(2);
    }

    [Fact]
    public async Task UpdateAsync_ShouldModifyDepartment()
    {
        // Arrange
        var department = new Department("Jurídico");
        await _repositoryBase.CreateAsync(department);

        department.Update("Legal");

        // Act
        var result = await _departmentRepository.UpdateAsync(department);

        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be("Legal");

        var dbDepartment = await _repositoryBase.GetAsync(department.Id);
        dbDepartment.Name.Should().Be("Legal");
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveDepartment()
    {
        // Arrange
        var department = new Department("Marketing");
        await _repositoryBase.CreateAsync(department);

        // Act
        await _departmentRepository.DeleteAsync(department);

        // Assert
        var dbDepartment = await _repositoryBase.GetAsync(department.Id);
        dbDepartment.Should().BeNull();
    }

    [Fact]
    public async Task CheckIfExists_ShouldReturnTrue_WhenDepartmentExists()
    {
        // Arrange
        var department = new Department ("TI");
        await _repositoryBase.CreateAsync(department);

        // Act
        var exists = await _departmentRepository.CheckIfExists(d => d.Name == "TI");

        // Assert
        exists.Should().BeTrue();
    }

    [Fact]
    public async Task CheckIfExists_ShouldReturnFalse_WhenDepartmentDoesNotExist()
    {
        // Act
        var exists = await _departmentRepository.CheckIfExists(d => d.Name == "Inexistente");

        // Assert
        exists.Should().BeFalse();
    }
}
