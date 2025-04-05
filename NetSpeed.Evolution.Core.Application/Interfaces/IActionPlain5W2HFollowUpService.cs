namespace NetSpeed.Evolution.Core.Application.Interfaces;

public interface IActionPlain5W2HFollowUpService
{
    public Task<bool> CheckIfExists(ActionPlain5W2HFollowUpFilter filter);
    public Task<ActionPlain5W2HFollowUpDto> CreateAsync(ActionPlain5W2HFollowUpInsertDto entity);
    public Task<ActionPlain5W2HFollowUpDto> DeleteAsync(long id);
    public Task<ActionPlain5W2HFollowUpDto> GetAsync(long id);
    public Task<IEnumerable<ActionPlain5W2HFollowUpDto>> GetAllAsync(ActionPlain5W2HFollowUpFilter filter);
    public Task<ActionPlain5W2HFollowUpDto> UpdateAsync(long id, ActionPlain5W2HFollowUpUpdateDto entity);
}
