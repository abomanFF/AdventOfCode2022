//Arrange
let sections = document
  .getElementsByTagName("pre")[0]
  .textContent.split("\n\n");

let crates = sections[0]
  .split("\n")
  .reverse()
  .splice(1)
  .reduce((a, b, i) => {
    for (let j = 1, l = 0; j < b.length; j += 4) {
      if (!a[l]) a[l] = [];
      if (b.charAt(j).trim()) a[l].push(b.charAt(j));
      l++;
    }
    return a;
  }, []);

let moves = sections[1]
  .split("\n")
  .filter((l) => l)
  .reduce((a, b) => {
    var match = b.match(/[0-9]+/g);
    a.push({
      move: parseInt("-" + match[0]),
      from: parseInt(match[1]) - 1,
      to: parseInt(match[2]) - 1,
    });
    return a;
  }, []);

//Act
moves.forEach((m) => {
  crates[m.to].push(...crates[m.from].splice(m.move));
});

//Assert
console.log(
  crates.reduce((a, b) => {
    a = a + b.pop();
    return a;
  }, "")
);
