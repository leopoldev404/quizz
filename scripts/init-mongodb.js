const databaseName = "quizz";
const collectionsNames = ["quizzes", "questions", "transactions", "scores"];

use(databaseName);

collectionsNames.forEach((value) => {
  db.createCollection(value);
});

db.quizzes.insertMany([
  {
    name: "history quiz",
    category: "history",
    description: "this quiz is intended for kids",
    difficulty: "easy",
    tags: [
      "history",
      "easy",
      "kids",
      "colombo",
      "french-revolution",
      "union-of-italy",
    ],
    createdAt: new Date(),
  },
  {
    name: "math quiz",
    category: "math",
    description: "this quiz is intended for teenagers",
    difficulty: "medium",
    tags: [
      "math",
      "medium",
      "teenagers",
      "additions",
      "fractions",
      "equations",
    ],
    createdAt: new Date(),
  },
]);
