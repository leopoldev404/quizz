using MediatR;
using QuizzService.Core.Quizzes.Queries;

namespace QuizzService.Api.Questions.Filters;

public class QuizIdValidationFilter : IEndpointFilter
{
    private readonly ISender sender;

    public QuizIdValidationFilter(ISender sender)
    {
        this.sender = sender;
    }

    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        string? quizId = context.HttpContext.Request.Query["quizId"];
        if (string.IsNullOrEmpty(quizId))
        {
            return Results.BadRequest("Missing Required Parameter");
        }

        var quiz = await sender.Send(new GetQuizByIdQuery(quizId));
        if (quiz is null)
        {
            return Results.NotFound($"QuizId:{quiz} not found");
        }

        return await next(context);
    }
}