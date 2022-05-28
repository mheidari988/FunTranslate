using FunTranslate.Application.Contracts.Persistence;
using FunTranslate.Application.Exceptions;
using FunTranslate.Application.Feature.Persistence.FunTranslations.Queries.GetFunTranslationBy;
using FunTranslate.Domain.Entities;

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
    public async Task Get_Translation_If_valid()
    {
        var funTranslationList = MockData.GetFunTranslatesMockData();
        _mockFunTranslationRepository.Setup(fun => fun.GetAllAsync()).ReturnsAsync(funTranslationList);
        _mockFunTranslationRepository.Setup(fun => fun.GetByTextAndTranslation(It.IsNotNull<string>(), It.IsNotNull<string>())).ReturnsAsync(new FunTranslation());

        var handler = new GetFunTranslationByQueryHandler(_mockFunTranslationRepository.Object, _mapper);
        var response = await handler.Handle(new GetFunTranslationByQuery { Text = "hello", Translation = "minion" }, CancellationToken.None);

        response.ShouldNotBeNull();
    }

    [Fact]
    public void Get_Throw_If_Emptry()
    {
        var funTranslationList = MockData.GetFunTranslatesMockData();
        _mockFunTranslationRepository.Setup(fun => fun.GetAllAsync()).ReturnsAsync(funTranslationList);
        _mockFunTranslationRepository.Setup(fun => fun.GetByTextAndTranslation(It.IsNotNull<string>(), It.IsNotNull<string>())).ReturnsAsync(new FunTranslation());

        var handler = new GetFunTranslationByQueryHandler(_mockFunTranslationRepository.Object, _mapper);
        handler.Handle(new GetFunTranslationByQuery(), CancellationToken.None).ShouldThrow<FunValidationException>();
    }
}
