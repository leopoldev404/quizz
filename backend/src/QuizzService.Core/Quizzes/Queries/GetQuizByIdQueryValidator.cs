using FluentValidation;
using Microsoft.AspNetCore.Http;
using QuizzService.Core.Abstractions;
using QuizzService.Core.Utils;

namespace QuizzService.Core.Quizzes.Queries;

public class GetQuizByIdQueryValidator : AbstractValidator<GetQuizByIdQuery>
{
    private readonly IQuizzesRepository quizzesRepository;

    public GetQuizByIdQueryValidator(IQuizzesRepository quizzesRepository)
    {
        this.quizzesRepository = quizzesRepository;

        RuleFor(query => query.QuizId)
            .Cascade(CascadeMode.Stop)
            .Matches(RegularExpressions.IsValidMongoId())
            .WithErrorCode(StatusCodes.Status400BadRequest.ToString())
            .WithMessage($"Invalid Quiz Id")
            .MustAsync(QuizIdExists)
            .WithErrorCode(StatusCodes.Status404NotFound.ToString())
            .WithMessage("Quiz Id Not found");
    }

    private async Task<bool> QuizIdExists(string quizId, CancellationToken token) =>
        await quizzesRepository.FindByIdAsync(new GetQuizByIdQuery(quizId)) is not null;
}