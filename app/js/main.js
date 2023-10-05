window.addEventListener("load", populateDropdown);

document.addEventListener("DOMContentLoaded", function () {
  const form = document.getElementById("myForm");

  form.addEventListener("submit", function (e) {
    e.preventDefault(); // Prevent the default form submission behavior

    // Get form data
    const formData = new FormData(form);

    // Convert form data to a JavaScript object
    const formObject = {};
    formData.forEach((value, key) => {
      formObject[key] = value;
    });

    // Store the form data in localStorage
    localStorage.setItem("formData", JSON.stringify(formObject));

    // Optionally, you can provide user feedback that the data has been saved
    alert("Form data saved to localStorage!");

    // Clear the form fields if needed
    form.reset();
  });
});

// async function populateDropdown() {
//   const quizzes = await axios.get("http://localhost:5000/api/quizzes");
//   console.log(quizzes.data);

//   const dropdown = document.getElementById("dropdown");
//   dropdown.innerHTML = "";

//   const defaultOption = document.createElement("option");
//   defaultOption.text = "Select an option";
//   defaultOption.value = "";
//   dropdown.appendChild(defaultOption);

//   quizzes.data.forEach((user) => {
//     const option = document.createElement("option");
//     option.text = user.name;
//     option.value = user.name;
//     dropdown.appendChild(option);
//   });
// }
