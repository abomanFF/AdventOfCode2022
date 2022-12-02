var rules = {
  A: { point: 1, win: "C", loss: "B" }, // A = ROCK 1
  B: { point: 2, win: "A", loss: "C" }, // B = PAPER 2
  C: { point: 3, win: "B", loss: "A" }, // C = SCISSOR 3
};

document
  .getElementsByTagName("pre")[0]
  .textContent.replaceAll(" ", "")
  .replaceAll("\n", "")
  .match(/.{2}/g)
  .reduce((a, b) => {
    let choices = b.split("");
    let sel = rules[choices[0]];
    if (choices[1] === "X") {
      //WIN
      let counter = rules[sel.loss];
      return a + counter.point + 6;
    }
    if (choices[1] === "Z") {
      //LOSS
      let counter = rules[sel.win];
      return a + counter.point;
    }
    return a + sel.point + 3;
  }, 0);
