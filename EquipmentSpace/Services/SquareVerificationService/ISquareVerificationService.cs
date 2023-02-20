namespace EquipmentSpace.Services.SquareVerificationService
{
    public interface ISquareVerificationService
    {
        bool VerifySquare(string spaceCode, string equipmentCode, int quantity);
    }
}
