
using MediatR;
using QuizzService.Core.Quizzes.Queries;

namespace QuizzService.Api.Quizzes.Filters;

public class QuizIdValidationEndpointFilter : IEndpointFilter
{
    private readonly ISender sender;

    public QuizIdValidationEndpointFilter(ISender sender)
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
            return Results.NotFound($"QuizId: {quizId} not found");
        }

        return await next(context);
    }
}