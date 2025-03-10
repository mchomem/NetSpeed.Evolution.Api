namespace NetSpeed.Evolution.Tests;

public class HardSkillUnitTest
{
    [Fact]
    public void Update_HardSkillEntity_ReturnHardSkillDeletedRecordHandlingException()
    {
        // Arrange
        var hardSkill = new HardSkill("C#");
        
        // Act
        hardSkill.Delete();
        
        // Act & Assert
        Assert.Throws<HardSkillDeletedRecordHandlingException>(() =>
        {
            hardSkill.Update("C# 9");
        });
    }

    [Fact]
    public void Delete_HardSkillEntity_ReturnHardSkillDeletedRecordHandlingException()
    {
        // Arrange
        var hardSkill = new HardSkill("C#");

        // Act
        hardSkill.Delete();
        
        // Act & Assert
        Assert.Throws<HardSkillDeletedRecordHandlingException>(() =>
        {
            hardSkill.Delete();
        });
    }
}
