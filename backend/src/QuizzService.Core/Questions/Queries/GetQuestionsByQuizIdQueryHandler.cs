using QuizzService.Core.Abstractions;
using QuizzService.Core.Questions.Models;

namespace QuizzService.Core.Questions.Queries;

public sealed class GetQuestionsByQuizIdQueryHandler : IQueryHandler<GetQuestionsByQuizIdQuery, List<Question>>
{
    private readonly IQuestionsRepository questionsRepository;

    public GetQuestionsByQuizIdQueryHandler(IQuestionsRepository questionsRepository)
    {
        this.questionsRepository = questionsRepository;
    }

    public async Task<List<Question>?> Handle(
        GetQuestionsByQuizIdQuery request,
        CancellationToken cancellationToken) =>
            await questionsRepository.GetByQuizIdAsync(request, cancellationToken);
}