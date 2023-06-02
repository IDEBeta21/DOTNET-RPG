using DotNetRPG.API.Controllers;
using DotNetRPG.API.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using Moq;
using DotNetRPG.API.Dtos.Character;
using DotNetRPG.API.Models;
using DotNetRPG.UnitTests.Fixtures;

namespace DotNetRPG.UnitTests.System.Controller;

public class TestCharacterController 
{
    #region GetAllCharacters
    [Fact]
    public async Task GetAllCharacters_OnSuccess_ReturnStatusCode200()
    {
        //Arrange
        var mockCharacterServices = new Mock<ICharacterService>();

        mockCharacterServices
            .Setup(service => service.GetAllCharacters())
            .Returns(GetAllCharactersFixtures.GetAllCharactersFixturesResponse());

        var sut = new CharacterController(mockCharacterServices.Object);

        //Act
        var result = (OkObjectResult)await sut.GetAllCharacters();

        //Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetAllCharacters_OnSuccess_InvokePayorDataRepoExactlyOnce()
    {
        //Arrange
        var mockCharacterServices = new Mock<ICharacterService>();

        mockCharacterServices
            .Setup(service => service.GetAllCharacters())
            .Returns(GetAllCharactersFixtures.GetAllCharactersFixturesResponse());

        var sut = new CharacterController(mockCharacterServices.Object);

        //Act
        var result = await sut.GetAllCharacters();

        //Assert
        mockCharacterServices.Verify(
            service => service.GetAllCharacters(),
            Times.Once()
            );
    }
    [Fact]
    public async Task GetAllCharacters_OnSuccess_ReturnsAllCharacters()
    {
        //Arrange
        var mockCharacterServices = new Mock<ICharacterService>();

        mockCharacterServices
            .Setup(service => service.GetAllCharacters())
            .Returns(GetAllCharactersFixtures.GetAllCharactersFixturesResponse());

        var sut = new CharacterController(mockCharacterServices.Object);

        //Act
        var result = await sut.GetAllCharacters();

        //Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectres = (OkObjectResult)result;
        objectres.Value.Should().BeOfType<ServiceResponse<List<GetCharacterDtoResponse>>>();
    }

    [Fact]
    public async Task GetAllCharacters_ReturnsNotFound()
    {
        //Arrange
        var mockCharacterServices = new Mock<ICharacterService>();

        mockCharacterServices
            .Setup(service => service.GetAllCharacters())
            .Returns(GetAllCharactersFixtures.GetAllCharactersFixturesNotFoundResponse());

        var sut = new CharacterController(mockCharacterServices.Object);

        //Act
        var result = await sut.GetAllCharacters();

        //Assert
        result.Should().BeOfType<NotFoundResult>();
    }
    #endregion
}