const database = "quizz";
const collections = ["questions", "candidates"];

use(database);
collections.forEach((value, index) => {
  db.createCollection(value);
});
