namespace NetSpeed.Evolution.Core.Application.DTOs;

public class ActionPlain5W2HFollowUpDto
{
    public long Id { get; set; }
    public long ActionPlain5W2HId { get; set; }
    public string Annotation { get; set; }
    public long CreatedById { get; set; }
    public long? UpdatedById { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public ActionPlain5W2H ActionPlain5W2H { get; set; }
    public User CreatedBy { get; set; }
    public User? UpdatedBy { get; set; }
}

public class ActionPlain5W2HFollowUpInsertDto
{
    public long ActionPlain5W2HId { get; set; }
    public string Annotation { get; set; }
    public long CreatedById { get; set; }
}

public class ActionPlain5W2HFollowUpUpdateDto
{
    public long Id { get; set; }
    public long ActionPlain5W2HId { get; set; }
    public string Annotation { get; set; }
    public long? UpdatedById { get; set; }
}
