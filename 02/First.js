const rules = {
  X: { point: 1, win: "C", loss: "B" },
  Y: { point: 2, win: "A", loss: "C" },
  Z: { point: 3, win: "B", loss: "A" },
};
document
  .getElementsByTagName("pre")[0]
  .textContent.replaceAll(/\s/g, "")
  .match(/.{2}/g)
  .reduce((a, b) => {
    let choices = b.split("");
    let sel = rules[choices[1]];
    if (choices[0] === sel.win) return a + sel.point + 6;
    if (choices[0] === sel.loss) return a + sel.point;
    return a + sel.point + 3;
  }, 0);
