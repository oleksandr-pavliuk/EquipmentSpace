using EquipmentSpace.Controllers;
using EquipmentSpace.DTOs;
using EquipmentSpace.Services.ContractService;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentSpace.Tests.Controller
{
    public class ContractControllerTest
    {
        private readonly IContractService _contractService;

        public ContractControllerTest()
        {
            _contractService = A.Fake<IContractService>();
        }

        [Fact]
        public void ContractController_GetAllContracts_ReturnOk()
        {
            //Arrange
            var controller = new ContractController(_contractService);

            //Act
            var result = controller.GetAllContracts();

            //Asset
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestResult));
        }

        [Fact]
        public void ContractController_CreateNewContract_ReturnOk()
        {
            //Arrange
            var controller = new ContractController(_contractService);
            var contact = A.Fake<ContractCreateDTO>();

            //Act
            var result = controller.CreateContractAsync(contact);

            //Asset
            result.Should().NotBeNull();
            result.Should().NotBeOfType(typeof(BadRequestResult));
        }
    }
}
