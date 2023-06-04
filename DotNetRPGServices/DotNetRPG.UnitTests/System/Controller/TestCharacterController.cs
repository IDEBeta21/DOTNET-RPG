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
    public async Task GetAllCharacters_OnSuccess_InvokeCharacterDataServicesExactlyOnce()
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
        result.Should().BeOfType<NotFoundObjectResult>();
    }
    #endregion

    #region GetCharacterById
    [Fact]
    public async Task GetCharacterById_OnSuccess_ReturnStatusCode200()
    {
        //Arrange
        var request = new GetSingleCharacterRequest
        {
            Id = 32
        };

        var mockCharacterServices = new Mock<ICharacterService>();

        mockCharacterServices
            .Setup(service => service.GetCharacterById(request))
            .Returns(GetCharacterByIdFixtures.GetCharacterByIdResponse());

        var sut = new CharacterController(mockCharacterServices.Object);

        //Act
        var result = (OkObjectResult)await sut.GetCharacterById(request);

        //Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetCharacterById_OnSuccess_InvokeCharacterDataServicesExactlyOnce()
    {
        //Arrange
        var request = new GetSingleCharacterRequest
        {
            Id = 32
        };

        var mockCharacterServices = new Mock<ICharacterService>();

        mockCharacterServices
            .Setup(service => service.GetCharacterById(request))
            .Returns(GetCharacterByIdFixtures.GetCharacterByIdResponse());

        var sut = new CharacterController(mockCharacterServices.Object);

        //Act
        var result = await sut.GetCharacterById(request);

        //Assert
        mockCharacterServices.Verify(
            service => service.GetCharacterById(request),
            Times.Once()
            );
    }
    [Fact]
    public async Task GetCharacterById_OnSuccess_ReturnCharacterById()
    {
        //Arrange
        var request = new GetSingleCharacterRequest
        {
            Id = 32
        };

        var mockCharacterServices = new Mock<ICharacterService>();

        mockCharacterServices
            .Setup(service => service.GetCharacterById(request))
            .Returns(GetCharacterByIdFixtures.GetCharacterByIdResponse());

        var sut = new CharacterController(mockCharacterServices.Object);

        //Act
        var result = await sut.GetCharacterById(request);

        //Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectres = (OkObjectResult)result;
        objectres.Value.Should().BeOfType<ServiceResponse<GetCharacterDtoResponse>>();
    }

    [Fact]
    public async Task GetCharacterById_ReturnsNotFound()
    {
        //Arrange
        var request = new GetSingleCharacterRequest
        {
            Id = 5
        };

        var mockCharacterServices = new Mock<ICharacterService>();

        mockCharacterServices
            .Setup(service => service.GetCharacterById(request))
            .Returns(GetCharacterByIdFixtures.GetCharacterByIdNotFoundResponse());

        var sut = new CharacterController(mockCharacterServices.Object);

        //Act
        var result = await sut.GetCharacterById(request);

        //Assert
        result.Should().BeOfType<NotFoundObjectResult>();
    }
    #endregion

    #region AddCharacter
    [Fact]
    public async Task AddCharacter_OnSuccess_ReturnStatusCode200()
    {
        //Arrange
        var request = new AddCharacterDtoRequest
        {
            Name = "Celestine",
            HitPoints = 100,
            Strength = 5,
            Defense = 5,
            Intelligence = 10,
            Class = RpgClass.Mage
        };

        var mockCharacterServices = new Mock<ICharacterService>();

        mockCharacterServices
            .Setup(service => service.AddCharacter(request))
            .Returns(AddCharacterFixtures.AddCharacterFixturesResponse);

        var sut = new CharacterController(mockCharacterServices.Object);

        //Act
        var result = (OkObjectResult)await sut.AddCharacter(request);

        //Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task AddCharacter_OnSuccess_InvokeCharacterDataServicesExactlyOnce()
    {
        //Arrange
        var request = new AddCharacterDtoRequest
        {
            Name = "Celestine",
            HitPoints = 100,
            Strength = 5,
            Defense = 5,
            Intelligence = 10,
            Class = RpgClass.Mage
        };

        var mockCharacterServices = new Mock<ICharacterService>();

        mockCharacterServices
            .Setup(service => service.AddCharacter(request))
            .Returns(AddCharacterFixtures.AddCharacterFixturesResponse);

        var sut = new CharacterController(mockCharacterServices.Object);

        //Act
        var result = await sut.AddCharacter(request);

        //Assert
        mockCharacterServices.Verify(
            service => service.AddCharacter(request),
            Times.Once()
            );
    }
    [Fact]
    public async Task AddCharacter_OnSuccess_ReturnCharacterById()
    {
        //Arrange
        var request = new AddCharacterDtoRequest
        {
            Name = "Celestine",
            HitPoints = 100,
            Strength = 5,
            Defense = 5,
            Intelligence = 10,
            Class = RpgClass.Mage
        };

        var mockCharacterServices = new Mock<ICharacterService>();

        mockCharacterServices
            .Setup(service => service.AddCharacter(request))
            .Returns(AddCharacterFixtures.AddCharacterFixturesResponse);

        var sut = new CharacterController(mockCharacterServices.Object);

        //Act
        var result = await sut.AddCharacter(request);

        //Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectres = (OkObjectResult)result;
        objectres.Value.Should().BeOfType<ServiceResponse<List<GetCharacterDtoResponse>>>();
    }
    #endregion
}