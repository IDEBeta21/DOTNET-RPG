using DotNetRPG.API.Controllers;
using DotNetRPG.API.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace DotNetRPG.UnitTests.System.Controller;

public class TestCharacterController : ControllerBase
{
    private ICharacterService _characterService;
    [Fact]
    public async Task Get_OnSuccess_ReturnStatusCode200()
    {
        //Arrange 
        
        var sut = new CharacterController(_characterService);

        //Act
        var result = (OkObjectResult)await sut.GetUniTestRes();

        //Assert
        result.StatusCode.Should().Be(200);
    }
}