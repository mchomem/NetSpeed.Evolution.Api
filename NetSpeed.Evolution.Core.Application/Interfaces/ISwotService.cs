namespace NetSpeed.Evolution.Core.Application.Interfaces;

public interface ISwotService
{
    public Task<bool> CheckIfExists(SwotFilter filter);
    public Task<SwotDto> CreateAsync(SwotInsertDto entity);
    public Task<SwotDto> UpdateAsync(long id, SwotUpdateDto entity);
    public Task<SwotDto> GetAsync(long employeeId, long cycleId);
}
