using FunTranslate.Application.Contracts.Infrastructure;
using FunTranslate.Application.Feature.Infrastructure.ExternalTranslation.Queries;
using FunTranslate.Application.Models.ExternalTranslation;


namespace FunTranslate.Application.UnitTests.Infrastructure.ExternalTranslation.Queries;
public class GetExternalTranslationQueryHandlerTests
{
    private readonly Mock<IExternalTranslationService> _mockExternalTranslationService;
    private readonly IMapper _mapper;

    public GetExternalTranslationQueryHandlerTests()
    {
        var mCnfgProvider = new MapperConfiguration(cnfg =>
        {
            cnfg.AddProfile<AutoMapperProfile>();
        });

        _mapper = mCnfgProvider.CreateMapper();

        _mockExternalTranslationService = new Mock<IExternalTranslationService>();
        _mockExternalTranslationService.Setup(x => x.TranslateAsync(It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(new TranslationResponse());
    }

    [Fact]
    public void Should_Throw_If_Empty_Request_Passed()
    {
        // Arrange
        var handler = new GetExternalTranslationQueryHandler(_mockExternalTranslationService.Object, _mapper);

        // Act
        handler.Handle(new GetExternalTranslationQuery(), CancellationToken.None)

            // Assert
            .ShouldThrow<FunValidationException>();
    }

    [Fact]
    public void Should_Throw_If_MaxLength_Not_Valid()
    {
        // Arrange
        var handler = new GetExternalTranslationQueryHandler(_mockExternalTranslationService.Object, _mapper);

        // Act
        handler.Handle(new GetExternalTranslationQuery
        {
            Text = MockData.LoremIpsum(FunTranslationConsts.Text.MaximumLength + 1),
            Translation = MockData.LoremIpsum(FunTranslationConsts.Translation.MaximumLength + 1)
        }, CancellationToken.None)

            // Assert
            .ShouldThrow<FunValidationException>();
    }

    [Fact]
    public async Task Should_Return_ExternalTranslationVm_If_Valid_Data()
    {
        // Arrange
        var handler = new GetExternalTranslationQueryHandler(_mockExternalTranslationService.Object, _mapper);

        // Act
        var response = await handler.Handle(new GetExternalTranslationQuery
        {
            Text = "foo",
            Translation = "foo"
        }, CancellationToken.None);

        // Assert
        response.ShouldBeOfType<ExternalTranslationVm>();
    }
}
