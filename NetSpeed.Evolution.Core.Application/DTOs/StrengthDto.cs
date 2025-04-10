﻿namespace NetSpeed.Evolution.Core.Application.DTOs;

public class StrengthDto
{
    public long Id { get; set; }
    public long SwotId { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
}

public class StrengthInsertDto
{
    public long SwotId { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
}

public class StrengthUpdateDto
{
    public long SwotId { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
}