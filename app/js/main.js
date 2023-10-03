window.addEventListener("load", populateDropdown);

async function populateDropdown() {
  const quizzes = await axios.get("http://localhost:5000/api/quizzes");
  console.log(quizzes.data);

  const dropdown = document.getElementById("dropdown");
  dropdown.innerHTML = "";

  const defaultOption = document.createElement("option");
  defaultOption.text = "Select an option";
  defaultOption.value = "";
  dropdown.appendChild(defaultOption);

  quizzes.data.forEach((user) => {
    const option = document.createElement("option");
    option.text = user.name;
    option.value = user.name;
    dropdown.appendChild(option);
  });
}
