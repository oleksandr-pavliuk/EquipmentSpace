using EquipmentSpace.DTOs;
using EquipmentSpace.Models;
using EquipmentSpace.Services.ContractService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentSpace.Controllers
{
    [Route("api/contracts")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contractService;

        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Contract>>> GetAllContracts() 
        {
            try
            {
                return Ok(await _contractService.GetContractsAsync());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateContract(ContractCreateDTO contract)
        {
            try
            {
                await _contractService.CreateContract(contract);
                return Ok("Contract was created . . .");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
