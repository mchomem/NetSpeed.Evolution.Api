﻿namespace NetSpeed.Evolution.Core.Domain.Entities;

public class Cycle : BaseEntity
{
    private Cycle() { }

    public Cycle(int year)
    {
        Year = year;
        Active = true;
        CreatedAt = DateTime.UtcNow;
    }

    public int Year { get; private set; }
    public bool Active { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public void Update(int year)
    {
        Year = year;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        Active = false;
        UpdatedAt = DateTime.UtcNow;
    }

    #region Navigation Properties

    public ICollection<Swot> Swots { get; private set; }
    public ICollection<ActionPlain5W2H> ActionPlains5W2H { get; private set; }

    #endregion
}
