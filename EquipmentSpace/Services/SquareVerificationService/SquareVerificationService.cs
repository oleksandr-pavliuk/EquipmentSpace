using EquipmentSpace.Exceptions;
using EquipmentSpace.Models;
using EquipmentSpace.Repository;

namespace EquipmentSpace.Services.SquareVerificationService
{
    public class SquareVerificationService : ISquareVerificationService
    {
        private readonly IRepository<Space> _spaceRepository;
        private readonly IRepository<Equipment> _equipmentRepository;
        public SquareVerificationService(IRepository<Space> spaceRepository, IRepository<Equipment> equipmentRepository)
        {
             _spaceRepository = spaceRepository;
            _equipmentRepository = equipmentRepository;
        }
        public bool VerifySquare(string spaceCode, string equipmentCode, int quantity)
        {
            Space space = new Space();
            Equipment equipment = new Equipment();
            try
            {
                space = _spaceRepository.Read(e => e.Code == spaceCode);
            }
            catch(Exception ex)
            {
                throw new NotFoundException(ExceptionMessage.spaceNotFoundMessage);
            }
            try
            {
                equipment = _equipmentRepository.Read(e => e.Code == equipmentCode);
            }
            catch(Exception ex)
            {
                throw new NotFoundException(ExceptionMessage.equipmentNotFoundMessage);
            }

            return ((equipment.Square * quantity <= space.Square) ? true : false);
        }
    }
}
