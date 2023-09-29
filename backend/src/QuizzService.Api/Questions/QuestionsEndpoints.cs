using MediatR;
using QuizzService.Api.Questions.Filters;

namespace QuizzService.Api.Questions;

public static class QuestionsEndpoints
{
    const string ROUTE = "api/questions";

    public static void MapQuestionsEndpoints(this WebApplication app)
    {
        app.MapGet(ROUTE, GetQuestionsByQuizIdAsync)
            .AddEndpointFilter<QuizIdValidationFilter>();
    }

    private async static ValueTask<IResult> GetQuestionsByQuizIdAsync(
        ISender sender,
        string quizId,
        int pageNumber = 0,
        int PageSize = 10)
    {
        // // var query = new GetQuestionsByQuizIdQuery(
        // //     request.QuizId,
        // //     request.PageNumber,
        // //     request.PageSize);

        // // var questions = await sender.Send(query);
        // var questions = new List<Question>
        // {
        //     new("guid", "la madonnna", new string[] {"", "", "", ""}, "", DateTime.Now, request.QuizId),
        //     new("guid", "la madonnna", new string[] {"", "", "", ""}, "", DateTime.Now, request.QuizId)
        // };

        // return questions.Count == 0
        //     ? Results.NotFound($"No Questions for QuizId: {request.QuizId}")
        //     : Results.Ok(questions);
        return Results.Ok();
    }
}