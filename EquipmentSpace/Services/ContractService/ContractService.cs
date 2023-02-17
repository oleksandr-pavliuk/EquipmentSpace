using EquipmentSpace.DTOs;
using EquipmentSpace.Exceptions;
using EquipmentSpace.Models;
using EquipmentSpace.Repository;
using EquipmentSpace.Services.SquareVerificationService;

namespace EquipmentSpace.Services.ContractService
{
    public class ContractService : IContractService
    {
        private readonly IRepository<Contract> _repository;
        private readonly ISquareVerificationService _squareVerificationService;
        public ContractService(IRepository<Contract> repository, ISquareVerificationService squareVerificationService) 
        {
            _repository = repository;
            _squareVerificationService = squareVerificationService;
        }
        public async Task<IEnumerable<Contract>> GetContractsAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task CreateContract(ContractCreateDTO contract)
        {
            bool verified = _squareVerificationService.VerifySquare(contract.IdSpace, contract.IdEquipment, contract.Count);

            if (verified)
            {
                await _repository.CreateAsync(new Contract()
                {
                    IdEquipment = contract.IdEquipment,
                    IdSpace = contract.IdSpace
                });
            }
            else throw new SpaceException(ExceptionMessage.spaceMessage);

            
        }
    }
}
