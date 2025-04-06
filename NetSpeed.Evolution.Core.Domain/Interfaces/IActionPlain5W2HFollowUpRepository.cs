namespace NetSpeed.Evolution.Core.Domain.Interfaces;

public interface IActionPlain5W2HFollowUpRepository
{
    public Task<ActionPlain5W2HFollowUp> CreateAsync(ActionPlain5W2HFollowUp entity);
    public Task<ActionPlain5W2HFollowUp> DeleteAsync(ActionPlain5W2HFollowUp entity);
    public Task<ActionPlain5W2HFollowUp> GetAsync(long id);
    public Task<IEnumerable<ActionPlain5W2HFollowUp>> GetAllAsync(Expression<Func<ActionPlain5W2HFollowUp, bool>> filter, IEnumerable<Expression<Func<ActionPlain5W2HFollowUp, object>>>? includes = null);
    public Task<ActionPlain5W2HFollowUp> UpdateAsync(ActionPlain5W2HFollowUp entity);
    public Task<bool> CheckIfExists(Expression<Func<ActionPlain5W2HFollowUp, bool>> filter);
}
