var rules = {
  A: { point: 1, win: "C", loss: "B" },
  B: { point: 2, win: "A", loss: "C" },
  C: { point: 3, win: "B", loss: "A" },
};
document
  .getElementsByTagName("pre")[0]
  .textContent.replaceAll(/\s/g, "")
  .match(/.{2}/g)
  .reduce((a, b) => {
    let choices = b.split("");
    let sel = rules[choices[0]];
    if (choices[1] === "Z") {
      let counter = rules[sel.loss];
      return a + counter.point + 6;
    }
    if (choices[1] === "X") {
      let counter = rules[sel.win];
      return a + counter.point;
    }
    return a + sel.point + 3;
  }, 0);
