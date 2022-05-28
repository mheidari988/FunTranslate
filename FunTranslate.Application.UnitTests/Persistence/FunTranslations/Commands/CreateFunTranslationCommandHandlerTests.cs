using FunTranslate.Application.Contracts.Persistence;
using FunTranslate.Application.Feature.Persistence.FunTranslations.Commands.CreateFunTranslation;

namespace FunTranslate.Application.UnitTests.Persistence.FunTranslations.Commands;
public class CreateFunTranslationCommandHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IAsyncRepository<FunTranslation>> _mockAsyncRepository;
    public CreateFunTranslationCommandHandlerTests()
    {
        var mCnfgProvider = new MapperConfiguration(cnfg =>
        {
            cnfg.AddProfile<AutoMapperProfile>();
        });
        _mapper = mCnfgProvider.CreateMapper();

        var funTranslatesList = MockData.GetFunTranslatesMockData();
        _mockAsyncRepository = new Mock<IAsyncRepository<FunTranslation>>();
        _mockAsyncRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(funTranslatesList);
        _mockAsyncRepository.Setup(repo => repo.AddAsync(It.IsAny<FunTranslation>())).ReturnsAsync((FunTranslation fun) =>
        {
            funTranslatesList.Add(fun);
            return fun;
        });
    }

    [Fact]
    public void Should_Throw_If_Empty_Request_Passed()
    {
        // Arrange
        var handler = new CreateFunTranslationCommandHandler(_mockAsyncRepository.Object, _mapper);

        // Act
        handler.Handle(new CreateFunTranslationCommand(), CancellationToken.None)

            // Assert
            .ShouldThrow<FunValidationException>();
    }

    [Fact]
    public void Should_Throw_If_MaxLength_Not_Valid()
    {
        // Arrange
        var handler = new CreateFunTranslationCommandHandler(_mockAsyncRepository.Object, _mapper);

        // Act
        handler.Handle(new CreateFunTranslationCommand
        {
            Text = MockData.LoremIpsum(FunTranslationConsts.Text.MaximumLength + 1),
            Translation = MockData.LoremIpsum(FunTranslationConsts.Translation.MaximumLength + 1),
            Translated = MockData.LoremIpsum(FunTranslationConsts.Translated.MaximumLength + 1)
        }, CancellationToken.None)

            // Assert
            .ShouldThrow<FunValidationException>();
    }

    [Fact]
    public async Task Should_Add_New_FunTranslation_If_Valid_Data()
    {
        // Arrange
        var handler = new CreateFunTranslationCommandHandler(_mockAsyncRepository.Object, _mapper);

        // Act
        await handler.Handle(new CreateFunTranslationCommand()
        {
            Text = "foo",
            Translation = "foo",
            Translated = "foo"
        }, CancellationToken.None);
        (await _mockAsyncRepository.Object.GetAllAsync())

            // Assert
            .Count.ShouldBe(5);
    }
}
