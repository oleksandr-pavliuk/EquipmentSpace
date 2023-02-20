using EquipmentSpace.DTOs;
using EquipmentSpace.Models;

namespace EquipmentSpace.Services.ContractService
{
    public interface IContractService
    {
        Task<IEnumerable<ContractShowDTO>> GetContractsAsync();
        Task CreateContractAsync(ContractCreateDTO contract);
    }
}
