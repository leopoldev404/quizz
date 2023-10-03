using MediatR;
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
        ISender sender,
        string quizId)
    {
        var quiz = await sender.Send(new GetQuizByIdQuery(quizId));
        return Results.Ok(quiz);
    }

    private async static ValueTask<IResult> GetQuizzesAsync(
        ISender sender,
        int pageNumber = 0,
        int PageSize = 10)
    {
        var quizzes = await sender.Send(new GetQuizzesQuery(pageNumber, PageSize));
        return Results.Ok(quizzes);
    }
}