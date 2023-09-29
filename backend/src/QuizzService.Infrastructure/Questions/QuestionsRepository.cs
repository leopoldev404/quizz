using MongoDB.Driver;
using QuizzService.Core.Abstractions;
using QuizzService.Core.Questions;
using QuizzService.Core.Questions.Queries;

namespace QuizzService.Infrastructure.Questions;
public class QuestionsRepository : IQuestionsRepository
{
    private readonly IMongoCollection<Question> questionsCollection;

    public QuestionsRepository(IMongoCollection<Question> questionsCollection)
    {
        this.questionsCollection = questionsCollection;
    }

    public async ValueTask<List<Question>?> FindByQuizIdAsync(GetQuestionsByQuizIdQuery query)
        => await questionsCollection.Find(question => question.QuizId == query.QuizId).ToListAsync();
}