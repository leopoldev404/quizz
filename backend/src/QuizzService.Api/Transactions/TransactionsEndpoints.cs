using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizzService.Api.Transactions.Requests;
using QuizzService.Core.Transactions.Commands;

namespace QuizzService.Api.Transactions;

public static class TransactionsEndpoints
{
    const string ROUTE = "api/transactions";

    public static void MapTransactionsEndpoints(this WebApplication app)
    {
        app.MapPost(ROUTE, CreateTransactionAsync);
    }

    private async static ValueTask<IResult> CreateTransactionAsync(
        [FromServices] ISender sender,
        [FromBody] CreateTransactionRequest request)
    {
        var transaction = await sender.Send(
            new CreateTransactionCommand(
                request.UserName,
                request.QuizId,
                request.QuestionId,
                request.GivenAnswer,
                request.AnswerIsCorrect));

        return Results.Ok(transaction);
    }
}