using MediatR;
using Moq;
using QuizzService.Core.Abstractions;
using QuizzService.Core.Quizzes.Models;
using QuizzService.Core.Quizzes.Queries;
using Xunit;

namespace QuizzService.UnitTests;

public class GetQuizByIdQueryHandlerTests
{
    private readonly Mock<IQuizzesRepository> quizzesRepositoryMock;
    private readonly GetQuizByIdQueryHandler handler;

    public GetQuizByIdQueryHandlerTests()
    {
        quizzesRepositoryMock = new Mock<IQuizzesRepository>();
        handler = new(quizzesRepositoryMock.Object);
    }

    [Fact]
    public async Task GetQuizByIdQueryHandlerRequestIsOkShouldReturnQuiz()
    {
        var query = new GetQuizByIdQuery("validId");

        quizzesRepositoryMock.Setup(repository => repository
            .GetByIdAsync(It.IsAny<string>(), CancellationToken.None))
            .ReturnsAsync(new Quiz());

        await handler.Handle(query, CancellationToken.None);

        quizzesRepositoryMock.Verify(repository =>
            repository.GetByIdAsync(query.QuizId, CancellationToken.None), Times.Once());

        quizzesRepositoryMock.VerifyNoOtherCalls();
    }

}