const questions = await getQuestionsByQuizId();
let questionIndex = -1;
let correctAnswers = 0;

function nextQuestion() {
  ++questionIndex;

  if (questionIndex >= questions.length) {
    localStorage.setItem(
      "score",
      JSON.stringify({
        total: questions.length,
        correctAnswers: correctAnswers,
      })
    );
    alert("Quiz Completed!");
    window.location.href = "score.html";
  }

  document.body.innerHTML = "";

  document.write(questions[questionIndex].text + "<br />");

  for (var j = 0; j < questions[questionIndex].options.length; j++) {
    document.write(
      `<input type=radio id=option name=option value=${questions[questionIndex].options[j]} >` +
        questions[questionIndex].options[j] +
        "<br />"
    );
  }

  if (questionIndex < questions.length) {
    var nextButton = document.createElement("input");
    nextButton.type = "button";
    nextButton.value = "Next question";
    nextButton.addEventListener("click", async () => {
      const question = questions[questionIndex];

      const selectedOption = document.querySelector(
        'input[name="option"]:checked'
      );

      if (!selectedOption) {
        alert("Please select an answer before submitting.");
        return;
      }

      const selectedAnswer = selectedOption.value;
      if (selectedAnswer == question.correctAnswer) {
        correctAnswers++;
      }
      await sendTransactionAsync(selectedAnswer, question);
      nextQuestion();
    });

    document.body.appendChild(nextButton);
  }
}

nextQuestion();

async function sendTransactionAsync(selectedOption, question) {
  let quizInformation = JSON.parse(
    localStorage.getItem("start-quiz-information")
  );

  let transaction = {
    quizId: quizInformation["quizId"],
    username: quizInformation["username"],
    questionId: question.id,
    givenAnswer: selectedOption,
    answerIsCorrect: question.correctAnswer == selectedOption,
  };

  await axios.post("http://localhost:5000/api/transactions", transaction);
}

async function getQuestionsByQuizId() {
  let quizInformation = JSON.parse(
    localStorage.getItem("start-quiz-information")
  );
  let quizId = quizInformation["quizId"];

  let questionsResponse = await axios.get(
    `http://localhost:5000/api/questions?quizId=${quizId}`
  );
  return questionsResponse.data;
}
