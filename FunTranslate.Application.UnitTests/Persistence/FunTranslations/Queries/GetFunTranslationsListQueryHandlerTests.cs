using FunTranslate.Application.Contracts.Persistence;
using FunTranslate.Application.Feature.Persistence.FunTranslations.Queries.GetFunTranslationsList;
using FunTranslate.Domain.Entities;

namespace FunTranslate.Application.UnitTests.Persistence.FunTranslations.Queries;
public class GetFunTranslationsListQueryHandlerTests
{
    private readonly Mock<IAsyncRepository<FunTranslation>> _mockAsyncRepository;
    private readonly IMapper _mapper;

    public GetFunTranslationsListQueryHandlerTests()
    {
        var mCnfgProvider = new MapperConfiguration(cnfg =>
        {
            cnfg.AddProfile<AutoMapperProfile>();
        });
        _mapper = mCnfgProvider.CreateMapper();

        var funTranslatesList = MockData.GetFunTranslatesMockData();
        _mockAsyncRepository = new Mock<IAsyncRepository<FunTranslation>>();
        _mockAsyncRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(funTranslatesList);
    }

    [Fact]
    public async Task Should_Return_List_Of_FunTranslationsListVm()
    {
        var handler = new GetFunTranslationsListQueryHandler(_mockAsyncRepository.Object, _mapper);

        var result = await handler.Handle(new GetFunTranslationsListQuery(), CancellationToken.None);

        result.ShouldBeOfType<List<FunTranslationsListVm>>();
        result.Count.ShouldBe(4);
    }
}
