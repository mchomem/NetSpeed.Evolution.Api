﻿namespace NetSpeed.Evolution.Core.Application.DTOs;

public class ThreatDto
{
    public long Id { get; set; }
    public long SwotId { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
}

public class ThreatInsertDto
{
    public long SwotId { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
}

public class ThreatUpdateDto
{
    public long SwotId { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
}
