using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizzService.Api.Scores.Requests;
using QuizzService.Core.Scores.Commands;

namespace QuizzService.Api.Scores;

public static class ScoresEndpoints
{
    const string ROUTE = "api/scores";

    public static void MapScoresEndpoints(this WebApplication app)
    {
        app.MapPost(ROUTE, CreateScoreAsync);
    }

    private async static ValueTask<IResult> CreateScoreAsync(
        [FromServices] ISender sender,
        [FromBody] CreateScoreRequest request)
    {
        var score = await sender.Send(
            new CreateScoreCommand(request.Username, request.QuizId, request.ScoreValue));

        return Results.Ok(score);
    }
}