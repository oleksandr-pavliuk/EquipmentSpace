namespace EquipmentSpace.DTOs
{
    public class ContractCreateDTO
    {
        public string SpaceCode { get; set; }
        public string EquipmentCode { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
