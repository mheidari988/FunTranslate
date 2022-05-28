using FunTranslate.Application.Contracts.Infrastructure;
using FunTranslate.Application.Exceptions;
using FunTranslate.Application.Feature.Infrastructure.ExternalTranslation.Queries;
using FunTranslate.Application.Models.ExternalTranslation;
using FunTranslate.Domain.Entities;

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
        var handler = new GetExternalTranslationQueryHandler(_mockExternalTranslationService.Object, _mapper);
        handler.Handle(new GetExternalTranslationQuery(), CancellationToken.None)

            .ShouldThrow<FunValidationException>();
    }

    [Fact]
    public void Should_Throw_If_MaxLength_Not_Valid()
    {
        var handler = new GetExternalTranslationQueryHandler(_mockExternalTranslationService.Object, _mapper);

        handler.Handle(new GetExternalTranslationQuery
        {
            Text = MockData.LoremIpsum(FunTranslationConsts.Text.MaximumLength + 1),
            Translation = MockData.LoremIpsum(FunTranslationConsts.Translation.MaximumLength + 1)
        }, CancellationToken.None)

            .ShouldThrow<FunValidationException>();
    }

    [Fact]
    public async Task Should_Return_ExternalTranslationVm_If_Valid_Data()
    {
        var handler = new GetExternalTranslationQueryHandler(_mockExternalTranslationService.Object, _mapper);
        var response = await handler.Handle(new GetExternalTranslationQuery
        {
            Text = "foo",
            Translation = "foo"
        }, CancellationToken.None);

        response.ShouldBeOfType<ExternalTranslationVm>();
    }
}
