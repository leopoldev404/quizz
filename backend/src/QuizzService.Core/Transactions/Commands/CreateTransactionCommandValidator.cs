using FluentValidation;

namespace QuizzService.Core.Transactions.Commands;

public sealed class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
{
    public CreateTransactionCommandValidator()
    {

    }
}