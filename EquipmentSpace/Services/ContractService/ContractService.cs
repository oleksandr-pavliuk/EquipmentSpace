using EquipmentSpace.DTOs;
using EquipmentSpace.Exceptions;
using EquipmentSpace.Models;
using EquipmentSpace.Repository;
using EquipmentSpace.Services.SquareVerificationService;
using Microsoft.EntityFrameworkCore;

namespace EquipmentSpace.Services.ContractService
{
    public class ContractService : IContractService
    {
        private readonly IRepository<Contract> _contractRepository;
        private readonly IRepository<Space> _spaceRepository;
        private readonly IRepository<Equipment> _equipmentRepository;
        private readonly ISquareVerificationService _squareVerificationService;
        public ContractService(IRepository<Contract> contractRepository, IRepository<Space> spaceRepository, IRepository<Equipment> equipmentRepository, ISquareVerificationService squareVerificationService) 
        {
            _contractRepository = contractRepository;
            _spaceRepository = spaceRepository;
            _equipmentRepository = equipmentRepository;
            _squareVerificationService = squareVerificationService;
        }
        public async Task<IEnumerable<ContractShowDTO>> GetContractsAsync()
        {

            var contracts = await _contractRepository.GetAllAsync();
            List<ContractShowDTO> contractsShow = new List<ContractShowDTO>();
            Space space = new Space();
            Equipment equipment = new Equipment();
            foreach(var item in contracts)
            {
                space = _spaceRepository.Read(s => s.Code == item.SpaceCode);
                equipment = _equipmentRepository.Read(e => e.Code == item.EquipmentCode);
                contractsShow.Add(new ContractShowDTO { SpaceName = space.Name, EquipmentName = equipment.Name, Quantity = item.Quantity});
            }
            return contractsShow;
        }
        public async Task CreateContractAsync(ContractCreateDTO contract)
        {
            bool verified = _squareVerificationService.VerifySquare(contract.SpaceCode, contract.EquipmentCode, contract.Quantity);

            if (verified)
            {
                await _contractRepository.CreateAsync(new Contract()
                {
                    EquipmentCode = contract.EquipmentCode,
                    SpaceCode = contract.SpaceCode,
                    Quantity = contract.Quantity
                });
            }
            else throw new SpaceException(ExceptionMessage.spaceMessage);

            
        }
    }
}
