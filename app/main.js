window.addEventListener("load", main);

async function main() {
  const quizzes = await getQuizzesAsync();

  populateDropdownAsync(quizzes);

  document
    .getElementById("start")
    .addEventListener("click", saveSelectedQuizAsync);
}

function saveSelectedQuizAsync() {
  let name = document.getElementById("input-name").value;
  let selectedQuizId = document.getElementById("quiz-select").value;

  if (!name || !selectedQuizId) {
    alert("Make sure you have filled in all the fields");
    return;
  }

  let startQuizInfo = {
    username: name,
    quizId: selectedQuizId,
  };

  localStorage.setItem("start-quiz-information", JSON.stringify(startQuizInfo));
  window.location.href = "questions.html";
}

function populateDropdownAsync(quizzes) {
  const dropdown = document.getElementById("quiz-select");
  dropdown.innerHTML = "";

  const defaultOption = document.createElement("option");
  defaultOption.text = "Select an option";
  defaultOption.value = "";
  dropdown.appendChild(defaultOption);

  quizzes.forEach((quiz) => {
    const option = document.createElement("option");
    option.text = quiz.name;
    option.value = quiz.id;
    dropdown.appendChild(option);
  });
}

async function getQuizzesAsync() {
  let quizzesResponse = await axios.get("http://localhost:5000/api/quizzes");
  return quizzesResponse.data;
}
