namespace NetSpeed.Evolution.Core.Application.Interfaces;

public interface IActionPlain5W2HService
{
    public Task<bool> CheckIfExists(ActionPlain5W2HFilter filter);
    public Task<ActionPlain5W2HDto> CreateAsync(ActionPlain5W2HInsertDto entity);
    public Task<IEnumerable<ActionPlain5W2HDto>> CreateManyAsync(IEnumerable<ActionPlain5W2HInsertDto> entities);
    public Task<ActionPlain5W2HDto> GetAsync(long id);
    public Task<IEnumerable<ActionPlain5W2HDto>> GetAllAsync(ActionPlain5W2HFilter filter);
    public Task<ActionPlain5W2HDto> UpdateAsync(long id, ActionPlain5W2HUpdateDto entity);
}
