namespace NetSpeed.Evolution.Tests;

public class JobTitleUnitTest
{
    [Fact]
    public void Update_JobTitleEntity_ReturnJobTitleDeletedRecordHandlingException()
    {
        // Arrange
        var jobTitle = new JobTitle("Developer");

        // Act
        jobTitle.Delete();

        // Act & Assert
        Assert.Throws<JobTitleDeletedRecordHandlingException>(() =>
        {
            jobTitle.Update("Software Developer");
        });
    }

    [Fact]
    public void Delete_JobTitleEntity_ReturnJobTitleDeletedRecordHandlingException()
    {
        // Arrange
        var jobTitle = new JobTitle("Developer");

        // Act
        jobTitle.Delete();

        // Act & Assert
        Assert.Throws<JobTitleDeletedRecordHandlingException>(() =>
        {
            jobTitle.Delete();
        });
    }
}
