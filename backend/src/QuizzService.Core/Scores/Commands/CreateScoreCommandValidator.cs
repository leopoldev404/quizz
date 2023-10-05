using FluentValidation;

namespace QuizzService.Core.Scores.Commands;

public sealed class CreateScoreCommandValidator : AbstractValidator<CreateScoreCommand>
{
    public CreateScoreCommandValidator()
    {

    }
}