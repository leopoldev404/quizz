using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizzService.Core.Quizzes.Queries;

namespace QuizzService.Api.Quizzes;

public static class QuizzesEndpoints
{
    const string ROUTE = "api/quizzes";

    public static void MapQuizzesEndpoints(this WebApplication app)
    {
        app.MapGet(ROUTE + "/{quizId}", GetQuizByIdAsync);
        app.MapGet(ROUTE, GetQuizzesAsync);
    }

    private async static ValueTask<IResult> GetQuizByIdAsync(
        [FromServices] ISender sender,
        [FromRoute] string quizId)
    {
        var quiz = await sender.Send(new GetQuizByIdQuery(quizId));
        return Results.Ok(quiz);
    }

    private async static ValueTask<IResult> GetQuizzesAsync(
        [FromServices] ISender sender,
        [FromQuery] int pageNumber = 0,
        [FromQuery] int PageSize = 10)
    {
        var quizzes = await sender.Send(new GetQuizzesQuery(pageNumber, PageSize));
        return Results.Ok(quizzes);
    }
}