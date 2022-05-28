namespace FunTranslate.Application.Feature.Persistence.FunTranslations.Commands.CreateFunTranslation;
public class CreateFunTranslationCommandHandler : IRequestHandler<CreateFunTranslationCommand, Guid>
{
    private readonly IAsyncRepository<FunTranslation> _repository;
    private readonly IMapper _mapper;

    public CreateFunTranslationCommandHandler(IAsyncRepository<FunTranslation> repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<Guid> Handle(CreateFunTranslationCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateFunTranslationCommandValidator();
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            throw new FunValidationException(validationResult);
        }

        var funFromDb = await _repository.AddAsync(_mapper.Map<FunTranslation>(request));

        return funFromDb.Id;
    }
}
