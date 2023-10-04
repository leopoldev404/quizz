using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizzService.Core.Questions.Queries;

namespace QuizzService.Api.Questions;

public static class QuestionsEndpoints
{
    const string ROUTE = "api/questions";

    public static void MapQuestionsEndpoints(this WebApplication app)
    {
        app.MapGet(ROUTE, GetQuestionsByQuizIdAsync);
    }

    private async static ValueTask<IResult> GetQuestionsByQuizIdAsync(
        [FromServices] ISender sender,
        [FromQuery] string quizId,
        [FromQuery] int pageNumber = 0,
        [FromQuery] int PageSize = 10)
    {
        var questions = await sender
            .Send(new GetQuestionsByQuizIdQuery(quizId, pageNumber, PageSize));

        return Results.Ok(questions);
    }
}