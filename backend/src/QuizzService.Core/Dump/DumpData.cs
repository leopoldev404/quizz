using QuizzService.Core.Questions.Commands;
using QuizzService.Core.Quizzes.Commands;

namespace QuizzService.Core.Dump;

public record DumpData(CreateQuizCommand Quiz, List<CreateQuestionCommand> Questions);