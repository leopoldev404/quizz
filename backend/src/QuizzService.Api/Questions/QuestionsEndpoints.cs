using MediatR;
using QuizzService.Core.Questions.Queries;
using QuizzService.Core.Quizzes.Queries;

namespace QuizzService.Api.Questions;

public static class QuestionsEndpoints
{
    const string ROUTE = "api/questions";

    public static void MapQuestionsEndpoints(this WebApplication app)
    {
        app.MapGet(ROUTE, GetQuestionsByQuizIdAsync);
    }

    private async static ValueTask<IResult> GetQuestionsByQuizIdAsync(
        ISender sender,
        string quizId,
        int pageNumber = 0,
        int PageSize = 10)
    {
        await sender.Send(new GetQuizByIdQuery(quizId));

        var questions = await sender.Send(
            new GetQuestionsByQuizIdQuery(quizId, pageNumber, PageSize));

        return Results.Ok(questions);
    }
}