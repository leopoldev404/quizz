using QuizzService.Core.Abstractions;

namespace QuizzService.Core.Quizzes.Queries;

public sealed class GetQuizByIdQueryHandler : IQueryHandler<GetQuizByIdQuery, Quiz>
{
    private readonly IQuizzesRepository quizzesRepository;

    public GetQuizByIdQueryHandler(IQuizzesRepository quizzesRepository)
    {
        this.quizzesRepository = quizzesRepository;
    }

    public async Task<Quiz?> Handle(
        GetQuizByIdQuery request,
        CancellationToken cancellationToken) =>
            await quizzesRepository.FindByIdAsync(request);
}