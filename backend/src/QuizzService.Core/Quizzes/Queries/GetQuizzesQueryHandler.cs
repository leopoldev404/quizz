using QuizzService.Core.Abstractions;

namespace QuizzService.Core.Quizzes.Queries;

public sealed class GetQuizzesQueryHandler : IQueryHandler<GetQuizzesQuery, List<Quiz>>
{
    private readonly IQuizzesRepository quizzesRepository;

    public GetQuizzesQueryHandler(IQuizzesRepository quizzesRepository)
    {
        this.quizzesRepository = quizzesRepository;
    }

    public async Task<List<Quiz>?> Handle(
        GetQuizzesQuery request,
        CancellationToken cancellationToken) =>
            await quizzesRepository.FindAllAsync(request);
}