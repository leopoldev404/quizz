using System.Text.Json;
using QuizzService.Core.Abstractions;
using QuizzService.Core.Dump;
using QuizzService.Core.Logging;
using QuizzService.Core.Questions.Models;
using QuizzService.Core.Quizzes.Models;

namespace QuizzService.Core.Quizzes.Commands;

public sealed class InitDbCommandHandler : ICommandHandler<InitDbCommand, bool>
{
    private readonly IQuizzesRepository quizzesRepository;
    private readonly IQuestionsRepository questionsRepository;
    private readonly ILogger logger;

    public InitDbCommandHandler(
        IQuestionsRepository questionsRepository,
        IQuizzesRepository quizzesRepository,
        ILogger logger)
    {
        this.questionsRepository = questionsRepository;
        this.quizzesRepository = quizzesRepository;
        this.logger = logger;
    }

    public async Task<bool> Handle(
        InitDbCommand request,
        CancellationToken cancellationToken)
    {
        using StreamReader file = File.OpenText("dump.json");

        var dumpData = JsonSerializer
            .Deserialize<List<DumpData>>(await file.ReadToEndAsync(cancellationToken));

        foreach (var data in dumpData)
        {
            var quiz = new Quiz
            {
                Name = data.Quiz.Name,
                Category = data.Quiz.Category,
                Description = data.Quiz.Description,
                Difficulty = data.Quiz.Difficulty,
                Tags = data.Quiz.Tags,
                CreatedAt = DateTime.UtcNow
            };

            await quizzesRepository.AddAsync(quiz);

            var questions = data.Questions.Select(question =>
                new Question
                {
                    Text = question.Text,
                    Options = question.Options,
                    CorrectAnswer = question.CorrectAnswer,
                    CreatedAt = DateTime.UtcNow,
                    QuizId = quiz.Id
                }).ToList();

            await questionsRepository.BulkInsertAsync(questions, cancellationToken);
        }

        return true;
    }
}