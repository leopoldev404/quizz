let jsonScore = localStorage.getItem("score");
let score = JSON.parse(jsonScore);

let startQuizInfoJson = localStorage.getItem("start-quiz-information");
let startQuizInfo = JSON.parse(startQuizInfoJson);

let scoreData = {
  score: score.correctAnswers,
  quizId: startQuizInfo.quizId,
  username: startQuizInfo.username,
};

await axios.post("http://localhost:5000/api/scores", scoreData);

document.getElementById(
  "score"
).textContent = `${score.correctAnswers} correct answers out of ${score.total} questions`;
