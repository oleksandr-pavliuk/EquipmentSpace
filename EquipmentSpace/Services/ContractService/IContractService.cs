using EquipmentSpace.DTOs;
using EquipmentSpace.Models;

namespace EquipmentSpace.Services.ContractService
{
    public interface IContractService
    {
        Task<IEnumerable<Contract>> GetContractsAsync();
        Task CreateContract(ContractCreateDTO contract);
    }
}
