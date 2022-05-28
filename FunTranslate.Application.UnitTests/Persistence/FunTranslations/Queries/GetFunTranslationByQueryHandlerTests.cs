using FunTranslate.Application.Contracts.Persistence;
using FunTranslate.Application.Feature.Persistence.FunTranslations.Queries.GetFunTranslationBy;

namespace FunTranslate.Application.UnitTests.Persistence.FunTranslations.Queries;
public class GetFunTranslationByQueryHandlerTests
{
    private readonly Mock<IFunTranslationRepository> _mockFunTranslationRepository;
    private IMapper _mapper;

    public GetFunTranslationByQueryHandlerTests()
    {
        var mCnfgProvider = new MapperConfiguration(cnfg =>
        {
            cnfg.AddProfile<AutoMapperProfile>();
        });
        _mapper = mCnfgProvider.CreateMapper();

        _mockFunTranslationRepository = new Mock<IFunTranslationRepository>();
    }

    [Fact]
    public void Should_Throw_If_Empty_Request_Passed()
    {
        // Arrange
        var funTranslationList = MockData.GetFunTranslatesMockData();
        _mockFunTranslationRepository.Setup(fun => fun.GetAllAsync()).ReturnsAsync(funTranslationList);
        _mockFunTranslationRepository.Setup(fun => fun.GetByTextAndTranslation(It.IsNotNull<string>(), It.IsNotNull<string>())).ReturnsAsync(new FunTranslation());

        // Act
        var handler = new GetFunTranslationByQueryHandler(_mockFunTranslationRepository.Object, _mapper);
        handler.Handle(new GetFunTranslationByQuery(), CancellationToken.None)

            // Assert
            .ShouldThrow<FunValidationException>();
    }

    [Fact]
    public void Should_Throw_If_MaxLength_Not_Valid()
    {
        // Arrange
        var handler = new GetFunTranslationByQueryHandler(_mockFunTranslationRepository.Object, _mapper);

        // Act
        handler.Handle(new GetFunTranslationByQuery
        {
            Text = MockData.LoremIpsum(FunTranslationConsts.Text.MaximumLength + 1),
            Translation = MockData.LoremIpsum(FunTranslationConsts.Translation.MaximumLength + 1),
        }, CancellationToken.None)

            // Assert
            .ShouldThrow<FunValidationException>();
    }

    [Fact]
    public async Task Should_Return_FunTranslationByVm_If_valid_Data()
    {
        // Arrange
        var funTranslationList = MockData.GetFunTranslatesMockData();
        _mockFunTranslationRepository.Setup(fun => fun.GetAllAsync()).ReturnsAsync(funTranslationList);
        _mockFunTranslationRepository.Setup(fun => fun.GetByTextAndTranslation(It.IsNotNull<string>(), It.IsNotNull<string>())).ReturnsAsync(new FunTranslation());

        // Act
        var handler = new GetFunTranslationByQueryHandler(_mockFunTranslationRepository.Object, _mapper);
        var response = await handler.Handle(new GetFunTranslationByQuery { Text = "foo", Translation = "foo" }, CancellationToken.None);

        // Assert
        response.ShouldNotBeNull();
    }
}
