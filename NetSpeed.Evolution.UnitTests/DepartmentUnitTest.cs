namespace NetSpeed.Evolution.Tests;

public class DepartmentUnitTest
{
    [Fact]
    public void Update_DepartmentEntity_ReturnDepartmentDeletedRecordHandlingException()
    {
        // Arrange
        var department = new Department("IT");
        
        // Act
        department.Delete();
        
        // Act & Assert
        Assert.Throws<DepartmentDeletedRecordHandlingException>(() =>
        {
            department.Update("Information Technology");
        });
    }

    [Fact]
    public void Delete_DepartmentEntity_ReturnDepartmentDeletedRecordHandlingException()
    {
        // Arrange
        var department = new Department("IT");

        // Act
        department.Delete();

        // Act & Assert
        Assert.Throws<DepartmentDeletedRecordHandlingException>(() =>
        {
            department.Delete();
        });
    }
}
